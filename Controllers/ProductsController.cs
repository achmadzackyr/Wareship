using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wareship.Authentication;
using Wareship.Model.Products;
using Wareship.Model.Stocks;
using Wareship.Services;
using Wareship.ViewModel.Auth;
using Wareship.ViewModel.Category;
using Wareship.ViewModel.Global;
using Wareship.ViewModel.Product;
using Wareship.ViewModel.Stock;
using Wareship.ViewModel.Warehouse;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBlobService _blobService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductsController(ApplicationDbContext context, IBlobService blobService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _blobService = blobService;
            this.userManager = userManager;
        }

        // GET: api/Products
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var productList = await _context.Product
                .Include(p => p.ProductImages)
                .Include(p=> p.ProductStatus)
                .Include(p=> p.Supplier)
                .Include(p => p.SubCategory)
                .ThenInclude(s => s.Category)
                .ToListAsync();

            var productDTOList = productList.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ChargeableWeight = p.ChargeableWeight,
                Description = p.Description,
                Price = p.Price,
                PriceString = "Rp" + (p.Price + (p.Price * p.Supplier.Markup * 0.01)).ToString("N0").Replace(',', '.'),
                Sku = p.Sku,
                Volume = p.Volume,
                Weight = p.Weight,
                Length = p.Length,
                Width = p.Width,
                Height = p.Height,
                UserId = p.UserId,
                ProductStatusId = p.ProductStatusId,
                ProductStatusName = p.ProductStatus.Name,
                Supplier = new SupplierProductDTO
                {
                    Id = p.Supplier.Id,
                    Brand = p.Supplier.Brand,
                    Markup = p.Supplier.Markup
                },
                SubCategory = new SubCategoryDTO
                {
                    Id = p.SubCategory.Id,
                    Name = p.SubCategory.Name,
                    ThumbnailUrl = p.SubCategory.ThumbnailUrl,
                    CategoryId = p.SubCategory.CategoryId,
                    Category = new CategoryDTO
                    {
                        Id = p.SubCategory.Category.Id,
                        Name = p.SubCategory.Category.Name,
                        ThumbnailUrl = p.SubCategory.Category.ThumbnailUrl
                    }
                },
                ProductImages = p.ProductImages.Select(p => new ProductImageDTO
                {
                    Id = p.Id,
                    Filename = p.Filename,
                    Url = "https://wareship.blob.core.windows.net/images/" + p.Filename,
                    ProductId = p.ProductId,
                    CreatedAt = p.CreatedAt
                }).ToList()
            }).ToList();

            var response = GenerateListResponse(StatusCodes.Status200OK, "Success", productDTOList);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("pagination")]
        public ActionResult<IEnumerable<Product>> GetProductPagination([FromBody] ProductPaginationModel param)
        {
            var source = _context.Product
                .OrderByDescending(x => x.Id)
                .AsQueryable();
            source = source.Include(p => p.ProductImages)
                .Include(p => p.ProductStatus)
                .Include(p => p.Supplier)
                .Include(p => p.SubCategory)
                .ThenInclude(s => s.Category);

            if (param.Parameter != null)
            {
                // Search & filtering
                if (param.Parameter.Filter != null)
                {
                    if (param.Parameter.Filter.Sku != null && param.Parameter.Filter.Sku != "")
                    {
                        source = source.Where(x => x.Sku.Contains(param.Parameter.Filter.Sku));
                    }
                    if (param.Parameter.Filter.Name != null && param.Parameter.Filter.Name != "")
                    {
                        source = source.Where(x => x.Name.Contains(param.Parameter.Filter.Name));
                    }
                    if (param.Parameter.Filter.Brand != null && param.Parameter.Filter.Brand != "")
                    {
                        source = source.Where(x => x.Supplier.Brand.Contains(param.Parameter.Filter.Brand));
                    }
                    if (param.Parameter.Filter.CategoryId != 0)
                    {
                        source = source.Where(x => x.SubCategory.CategoryId == param.Parameter.Filter.CategoryId);
                    }
                    if (param.Parameter.Filter.SubCategoryId != 0)
                    {
                        source = source.Where(x => x.SubCategoryId == param.Parameter.Filter.SubCategoryId);
                    }
                    if (param.Parameter.Filter.ProductStatusId != 0)
                    {
                        source = source.Where(x => x.ProductStatusId == param.Parameter.Filter.ProductStatusId);
                    }
                    if (param.Parameter.Filter.PriceFrom != 0)
                    {
                        source = source.Where(x => x.Price >= param.Parameter.Filter.PriceFrom);
                    }
                    if (param.Parameter.Filter.PriceTo != 0)
                    {
                        source = source.Where(x => x.Price <= param.Parameter.Filter.PriceTo);
                    }
                }

                // Ordering
                if (param.Parameter.Sort != null)
                {
                    if (param.Parameter.Sort.Price != null && param.Parameter.Sort.Price != "")
                    {
                        if (param.Parameter.Sort.Price == "ASC")
                        {
                            source = source.OrderBy(x => x.Price);
                        }
                        else
                        {
                            source = source.OrderByDescending(x => x.Price);
                        }
                    }
                    if (param.Parameter.Sort.CreatedAt != null && param.Parameter.Sort.CreatedAt != "")
                    {
                        if (param.Parameter.Sort.CreatedAt == "ASC")
                        {
                            // source = source.OrderBy(x => x.CreatedAt);
                            source = source.OrderBy(x => x.Id);
                        }
                        else
                        {
                            // source = source.OrderByDescending(x => x.CreatedAt);
                            source = source.OrderByDescending(x => x.Id);
                        }
                    }
                }
            }

            // Get's No of Rows Count   
            int count = source.Count();

            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            int CurrentPage = param.Paging.pageNumber;

            // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
            int PageSize = param.Paging.pageSize;

            // Display TotalCount to Records to User  
            int TotalCount = count;

            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            // Returns List of Product after applying Paging   
            var items = source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            // if CurrentPage is greater than 1 means it has previousPage  
            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage means it has nextPage  
            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            // Object which we are going to send in header   
            //var paginationMetadata = new
            //{
            //    totalCount = TotalCount,
            //    pageSize = PageSize,
            //    currentPage = CurrentPage,
            //    totalPages = TotalPages,
            //    previousPage,
            //    nextPage
            //};

            var pagingResponse = new PagingResponse
            {
                Page = CurrentPage,
                Limit = PageSize,
                TotalPage = TotalPages,
                TotalRecord = TotalCount
            };

            // Setting Header  
            // HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));

            var productDTOList = items.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ChargeableWeight = p.ChargeableWeight,
                Description = p.Description,
                Price = p.Price,
                PriceString = "Rp" + (p.Price + (p.Price * p.Supplier.Markup * 0.01)).ToString("N0").Replace(',', '.'),
                Sku = p.Sku,
                Volume = p.Volume,
                Weight = p.Weight,
                Length = p.Length,
                Width = p.Width,
                Height = p.Height,
                UserId = p.UserId,
                ProductStatusId = p.ProductStatusId,
                ProductStatusName = p.ProductStatus.Name,
                Supplier = new SupplierProductDTO
                {
                    Id = p.Supplier.Id,
                    Brand = p.Supplier.Brand,
                    Markup = p.Supplier.Markup
                },
                SubCategory = new SubCategoryDTO
                {
                    Id = p.SubCategory.Id,
                    Name = p.SubCategory.Name,
                    ThumbnailUrl = p.SubCategory.ThumbnailUrl,
                    CategoryId = p.SubCategory.CategoryId,
                    Category = new CategoryDTO
                    {
                        Id = p.SubCategory.Category.Id,
                        Name = p.SubCategory.Category.Name,
                        ThumbnailUrl = p.SubCategory.Category.ThumbnailUrl
                    }
                },
                ProductImages = p.ProductImages.Select(p => new ProductImageDTO
                {
                    Id = p.Id,
                    Filename = p.Filename,
                    Url = "https://wareship.blob.core.windows.net/images/" + p.Filename,
                    ProductId = p.ProductId,
                    CreatedAt = p.CreatedAt
                }).ToList(),
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();

            var response = GeneratePagingResponse(StatusCodes.Status200OK, "Success", productDTOList, pagingResponse);
            return Ok(response);
        }

        // GET: api/Products/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var p = await _context.Product
                .Where(p => p.Id == id)
                .Include(p => p.ProductImages)
                .Include(p => p.Supplier)
                .Include(p => p.ProductStatus)
                .Include(p => p.Stocks)
                .ThenInclude(w => w.Warehouse)
                .Include(p => p.Stocks)
                .ThenInclude(o => o.Option)
                .ThenInclude(v => v.Variation)
                .Include(p => p.SubCategory)
                .ThenInclude(s => s.Category)
                .Include(p => p.User)
                .AsSplitQuery()
                .OrderBy(p => p.Id)
                .FirstOrDefaultAsync();

            if (p == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Product Not Found", null));
            }

            var productDTO = new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ChargeableWeight = p.ChargeableWeight,
                Description = p.Description,
                Price = p.Price,
                PriceString = "Rp"+ p.Price.ToString("N0").Replace(',', '.'),
                Sku = p.Sku,
                Volume = p.Volume,
                Length = p.Length,
                Width = p.Width,
                Height = p.Height,
                Weight = p.Weight,
                UserId = p.UserId,
                CreatedAt = p.CreatedAt,
                CreatedAtString = p.CreatedAt.ToString("dddd, dd-MMM-yyyy HH:mm:ss"),
                UpdatedAt = p.UpdatedAt,
                UpdatedAtString = p.UpdatedAt.ToString("dddd, dd-MMM-yyyy HH:mm:ss"),
                User = new UserDTO
                {
                    //City = p.User.City,
                    Name = p.User.Name,
                    //Phone = p.User.Phone,
                    ProfilePictureUrl = p.User.ProfilePictureUrl,
                    //Province = p.User.Province,
                    //Street = p.User.Street,
                    //Subdistrict = p.User.Subdistrict,
                    //ZipCode = p.User.ZipCode
                },
                ProductStatusId = p.ProductStatusId,
                ProductStatusName = p.ProductStatus.Name,
                SubCategory = new SubCategoryDTO
                {
                    Id = p.SubCategory.Id,
                    Name = p.SubCategory.Name,
                    ThumbnailUrl = p.SubCategory.ThumbnailUrl,
                    CategoryId = p.SubCategory.CategoryId,
                    Category = new CategoryDTO
                    {
                        Id = p.SubCategory.Category.Id,
                        Name = p.SubCategory.Category.Name,
                        ThumbnailUrl = p.SubCategory.Category.ThumbnailUrl
                    }
                },
                ProductImages = p.ProductImages.Select(p => new ProductImageDTO
                {
                    Id = p.Id,
                    Filename = p.Filename,
                    ProductId = p.ProductId,
                    Url = "https://wareship.blob.core.windows.net/images/" + p.Filename,
                    CreatedAt = p.CreatedAt
                }).ToList(),
                Stocks = p.Stocks.Select(p => new StockDTO
                {
                    Id = p.Id,
                    Sku = p.Sku,
                    Quantity = p.Quantity,
                    ProductId = p.ProductId,
                    CreatedAt = p.CreatedAt,
                    Option = new OptionDTO
                    {
                        Id = p.Option.Id,
                        Name = p.Option.Name,
                        Variation = new VariationDTO
                        {
                            Id = p.Option.Variation.Id,
                            Name = p.Option.Variation.Name
                        }
                    },
                    WarehouseId = p.Warehouse.Id,
                    Warehouse = new WarehouseDTO
                    {
                        Id = p.Warehouse.Id,
                        //Name = p.Warehouse.Name,
                        //City = p.Warehouse.City,
                        //Subdistrict = p.Warehouse.Subdistrict,
                        //Phone = p.Warehouse.Phone,
                        //Province = p.Warehouse.Province,
                        //Street = p.Warehouse.Street,
                        //ZipCode = p.Warehouse.ZipCode
                    }
                })
                .ToList()
            };

            var response = GenerateResponse(StatusCodes.Status200OK, "Success", productDTO);
            return Ok(response);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromForm] ProductRequest request)
        {
            if (id != request.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest, GenerateResponse(StatusCodes.Status400BadRequest, "Product Id did not match with url", null));
            }

            try
            {
                string Username = User.FindFirst(ClaimTypes.Name)?.Value;
                var user = await userManager.FindByNameAsync(Username);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, Username);
                }

                var sekarang = DateTime.Now;
                var volume = (request.Length * request.Width * request.Height) / 6000;
                double cas = 0.0;
                if (volume > request.Weight)
                {
                    cas = volume;
                }
                else
                {
                    cas = request.Weight;
                }
                var product = new Product
                {
                    Id = request.Id,
                    Sku = request.Sku,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Weight = request.Weight,
                    Length = request.Length,
                    Width = request.Width,
                    Height = request.Height,
                    Volume = volume,
                    ChargeableWeight = cas,
                    UserId = user.Id, //updated by
                    ProductStatusId = request.ProductStatusId,
                    SubCategoryId = request.SubCategoryId,
                    SupplierId = request.SupplierId,
                    UpdatedAt = DateTime.Now
                };

                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                if(request.ProductImages != null)
                {
                    if (request.ProductImages.Count() > 0)
                    {
                        //delete all current image
                        var currentImageList = await _context
                            .ProductImage.Where(im => im
                            .ProductId == product.Id)
                            .ToListAsync();

                        foreach (var currentImage in currentImageList)
                        {
                            var del = await _blobService.DeleteBlob(currentImage.Filename, "images");
                            if (del)
                            {
                                _context.ProductImage.Remove(currentImage);
                                await _context.SaveChangesAsync();
                            }
                        }

                        //add new image
                        var i = 1;
                        foreach (var img in request.ProductImages)
                        {
                            var fileName = request.Name.Trim().Replace(" ", "-") + "-" + i + "-" + sekarang.ToString("ddMMyyyyhhmmss") + Path.GetExtension(img.FileName);
                            var res = await _blobService.UploadBlob(fileName, img, "images");
                            if (res)
                            {
                                var productImage = new ProductImage
                                {
                                    ProductId = product.Id,
                                    CreatedAt = sekarang,
                                    Filename = fileName
                                };

                                _context.ProductImage.Add(productImage);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "Failed to upload images", null));
                            }
                            i++;
                        }
                    }
                }
                
                if(request.Stocks != null)
                {
                    if (request.Stocks.Count() > 0)
                    {
                        //delete all current stock
                        var currentStockList = await _context
                            .Stock.Where(s => s
                            .ProductId == product.Id)
                            .ToListAsync();

                        foreach (var currentStock in currentStockList)
                        {
                            _context.Stock.Remove(currentStock);
                            await _context.SaveChangesAsync();
                        }

                        //add new stock
                        foreach (var s in request.Stocks)
                        {
                            var stock = new Stock
                            {
                                Sku = s.Sku,
                                Quantity = s.Quantity,
                                ProductId = product.Id,
                                OptionId = s.OptionId,
                                WarehouseId = s.WarehouseId,
                                CreatedAt = sekarang,
                                IsTrash = 0
                            };

                            _context.Stock.Add(stock);
                            await _context.SaveChangesAsync();
                        }
                    }
                }

                var p = await _context.Product
                .Include(p => p.Supplier)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductStatus)
                .Include(p => p.Stocks)
                .ThenInclude(w => w.Warehouse)
                .Include(p => p.Stocks)
                .ThenInclude(o => o.Option)
                .ThenInclude(v => v.Variation)
                .Include(p => p.SubCategory)
                .ThenInclude(s => s.Category)
                .Include(p => p.User)
                .AsSplitQuery()
                .OrderBy(p => p.Id)
                .SingleAsync(p => p.Id == id);

                if (p == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Product Not Found", null));
                }

                var productDTO = new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    ChargeableWeight = p.ChargeableWeight,
                    Description = p.Description,
                    Price = p.Price,
                    PriceString = "Rp" + p.Price.ToString("N0").Replace(',', '.'),
                    Sku = p.Sku,
                    Volume = p.Volume,
                    Length = p.Length,
                    Width = p.Width,
                    Height = p.Height,
                    Weight = p.Weight,
                    UserId = p.UserId,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Supplier = new SupplierProductDTO
                    {
                        Id = p.Supplier.Id,
                        Brand = p.Supplier.Brand,
                        Markup = p.Supplier.Markup
                    },
                    User = new UserDTO
                    {
                        Name = p.User.Name,
                        ProfilePictureUrl = p.User.ProfilePictureUrl,
                    },
                    ProductStatusId = p.ProductStatusId,
                    ProductStatusName = p.ProductStatus.Name,
                    SubCategory = new SubCategoryDTO
                    {
                        Id = p.SubCategory.Id,
                        Name = p.SubCategory.Name,
                        ThumbnailUrl = p.SubCategory.ThumbnailUrl,
                        CategoryId = p.SubCategory.CategoryId,
                        Category = new CategoryDTO
                        {
                            Id = p.SubCategory.Category.Id,
                            Name = p.SubCategory.Category.Name,
                            ThumbnailUrl = p.SubCategory.Category.ThumbnailUrl
                        }
                    }
                };

                if(p.ProductImages != null)
                {
                    productDTO.ProductImages = p.ProductImages.Select(p => new ProductImageDTO
                    {
                        Id = p.Id,
                        Filename = p.Filename,
                        ProductId = p.ProductId,
                        Url = "https://wareship.blob.core.windows.net/images/" + p.Filename,
                        CreatedAt = p.CreatedAt
                    }).ToList();
                };

                if (p.Stocks != null)
                {
                    productDTO.Stocks = p.Stocks.Select(p => new StockDTO
                    {
                        Id = p.Id,
                        Sku = p.Sku,
                        Quantity = p.Quantity,
                        ProductId = p.ProductId,
                        CreatedAt = p.CreatedAt,
                        Option = new OptionDTO
                        {
                            Id = p.Option.Id,
                            Name = p.Option.Name,
                            Variation = new VariationDTO
                            {
                                Id = p.Option.Variation.Id,
                                Name = p.Option.Variation.Name
                            }
                        },
                        WarehouseId = p.Warehouse.Id,
                        Warehouse = new WarehouseDTO
                        {
                            Id = p.Warehouse.Id,
                            //Name = p.Warehouse.Name
                            //City = p.Warehouse.City,
                            //Subdistrict = p.Warehouse.Subdistrict,
                            //Phone = p.Warehouse.Phone,
                            //Province = p.Warehouse.Province,
                            //Street = p.Warehouse.Street,
                            //ZipCode = p.Warehouse.ZipCode
                        }
                    })
                    .ToList();
                };

                return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", productDTO));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Product Not Found", null));
                }
                else
                {
                    throw;
                }
            }
        }

        private static double Bulatkan(double angka)
        {
            var result = Math.Floor(angka);
            if (result < 1)
            {
                result += 1;
            }
            else
            {
                var dec = angka % 1;
                if (dec > 0.300001)
                {
                    result += 1;
                }
            }
            return result;
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromForm] ProductRequest request)
        {
            if (ModelState.IsValid)
            {
                string Username = User.FindFirst(ClaimTypes.Name)?.Value;
                var user = await userManager.FindByNameAsync(Username);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, Username);
                }

                var volume = Bulatkan((request.Length * request.Width * request.Height) / 6000);
                var gross = Bulatkan(request.Weight);
                double cas = 0.0;
                if(volume > gross )
                {
                    cas = volume;
                } else
                {
                    cas = gross;
                }
                var product = new Product
                {
                    Sku = request.Sku,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Weight = request.Weight,
                    Length = request.Length,
                    Width = request.Width,
                    Height = request.Height,
                    Volume = volume,
                    ChargeableWeight = cas,
                    UserId = user.Id, // created by
                    ProductStatusId = 1,
                    SubCategoryId = request.SubCategoryId,
                    SupplierId = request.SupplierId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                try
                {
                    _context.Product.Add(product);
                    await _context.SaveChangesAsync();

                    var sekarang = DateTime.Now;

                    var productDTO = new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        ChargeableWeight = product.ChargeableWeight,
                        Description = product.Description,
                        Price = product.Price,
                        PriceString = "Rp" + product.Price.ToString("N0").Replace(',', '.'),
                        Sku = product.Sku,
                        Volume = product.Volume,
                        Weight = product.Weight,
                        Length = product.Length,
                        Width = product.Width,
                        Height = product.Height,
                        UserId = product.UserId,
                        ProductStatusId = product.ProductStatusId,
                        SubCategory = new SubCategoryDTO
                        {
                            Id = product.SubCategoryId
                        },
                        Supplier = new SupplierProductDTO
                        {
                            Id = product.SupplierId
                        },
                        CreatedAt = product.CreatedAt,
                        UpdatedAt = product.UpdatedAt
                    };

                    //add new image
                    if (request.ProductImages != null)
                    {
                        var i = 1;
                        foreach (var img in request.ProductImages)
                        {
                            var fileName = request.Name.Trim().Replace(" ", "-") + "-" + i + "-" + sekarang.ToString("ddMMyyyyhhmmss") + Path.GetExtension(img.FileName);
                            var res = await _blobService.UploadBlob(fileName, img, "images");
                            if (res)
                            {
                                var productImage = new ProductImage
                                {
                                    ProductId = product.Id,
                                    CreatedAt = sekarang,
                                    Filename = fileName
                                };

                                _context.ProductImage.Add(productImage);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "Failed to upload images", null));
                            }
                            i++;
                        }

                        productDTO.ProductImages = product.ProductImages.Select(p => new ProductImageDTO
                        {
                            Id = p.Id,
                            Filename = p.Filename,
                            Url = "https://wareship.blob.core.windows.net/images/" + p.Filename,
                            ProductId = p.ProductId,
                            CreatedAt = p.CreatedAt
                        }).ToList();
                    }

                    //add stock
                    if(request.Stocks != null)
                    {
                        foreach (var s in request.Stocks)
                        {
                            var stock = new Stock
                            {
                                Sku = s.Sku,
                                Quantity = s.Quantity,
                                ProductId = product.Id,
                                OptionId = s.OptionId,
                                WarehouseId = s.WarehouseId,
                                CreatedAt = sekarang,
                                IsTrash = 0
                            };

                            _context.Stock.Add(stock);
                            await _context.SaveChangesAsync();
                        }

                        productDTO.Stocks = product.Stocks.Select(s => new StockDTO
                        {
                            Id = s.Id,
                            Sku = s.Sku,
                            Quantity = s.Quantity,
                            ProductId = s.ProductId,
                            OptionId = s.OptionId,
                            WarehouseId = s.WarehouseId,
                            CreatedAt = s.CreatedAt,
                            IsTrash = s.IsTrash
                        }).ToList();
                    }

                    return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", productDTO));
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, ex.Message, null));
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, GenerateResponse(StatusCodes.Status400BadRequest, "Error", null));
            }
        }

        // DELETE: api/Products/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Product Not Found", null));
            }

            _context.Product.Remove(product);
            var isSuccess = await _context.SaveChangesAsync();
            if (isSuccess > 0)
            {
                return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", null));
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "Failed to delete", null));
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

        private ProductListResponse GenerateListResponse(int statusCode, string message, List<ProductDTO> response)
        {
            var stat = new Status();
            var resp = new ProductListResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;

            return resp;
        }

        private ProductPagingResponse GeneratePagingResponse(int statusCode, string message, List<ProductDTO> response, PagingResponse paging)
        {
            var stat = new Status();
            var resp = new ProductPagingResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;
            resp.Paging = paging;

            return resp;
        }

        private ProductResponse GenerateResponse(int statusCode, string message, ProductDTO response)
        {
            var stat = new Status();
            var resp = new ProductResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;

            return resp;
        }
    }
}
