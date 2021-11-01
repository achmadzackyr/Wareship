using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public ProductsController(ApplicationDbContext context, IBlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        // GET: api/Products
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var productList = await _context.Product
                .Include(p => p.ProductImages)
                .Include(p=> p.ProductStatus)
                .ToListAsync();

            var productDTOList = productList.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ChargeableWeight = p.ChargeableWeight,
                Description = p.Description,
                Price = p.Price,
                PriceString = "Rp" + p.Price.ToString("N0").Replace(',', '.'),
                Sku = p.Sku,
                Volume = p.Volume,
                Weight = p.Weight,
                UserId = p.UserId,
                ProductStatusId = p.ProductStatusId,
                ProductStatusName = p.ProductStatus.Name,
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

        // GET: api/Products/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var p = await _context.Product
                .Where(p => p.Id == id)
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
                Weight = p.Weight,
                UserId = p.UserId,
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
                var sekarang = DateTime.Now;

                var product = new Product
                {
                    Id = request.Id,
                    Sku = request.Sku,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Weight = request.Weight,
                    Volume = request.Volume,
                    ChargeableWeight = request.ChargeableWeight,
                    UserId = request.UserId,
                    ProductStatusId = request.ProductStatusId,
                    SubCategoryId = request.SubCategoryId
                };

                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                if(request.ProductImages.Count() > 0)
                {
                    //delete all current image
                    var currentImageList = await _context
                        .ProductImage.Where(im => im
                        .ProductId == product.Id)
                        .ToListAsync();

                    foreach (var currentImage in currentImageList)
                    {
                        var del = await _blobService.DeleteBlob(currentImage.Filename, "images");
                        if(del)
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
                
                if(request.Stocks.Count() > 0)
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


                var p = await _context.Product
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
                    Weight = p.Weight,
                    UserId = p.UserId,
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromForm] ProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var sub = await _context.SubCategory.FindAsync(request.SubCategoryId);
                if(sub != null)
                {
                    var product = new Product
                    {
                        Sku = request.Sku,
                        Name = request.Name,
                        Description = request.Description,
                        Price = request.Price,
                        Weight = request.Weight,
                        Volume = request.Volume,
                        ChargeableWeight = request.ChargeableWeight,
                        UserId = request.UserId,
                        ProductStatusId = 1,
                        SubCategoryId = request.SubCategoryId
                    };
                    try
                    {
                        _context.Product.Add(product);
                        await _context.SaveChangesAsync();

                        //add new image
                        var i = 1;
                        var sekarang = DateTime.Now;
                        foreach (var img in request.ProductImages)
                        {
                            var fileName = request.Name.Trim().Replace(" ","-") + "-" + i + "-" + sekarang.ToString("ddMMyyyyhhmmss") + Path.GetExtension(img.FileName);
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

                        //add stock
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
                            UserId = product.UserId,
                            ProductStatusId = product.ProductStatusId,
                            ProductImages = product.ProductImages.Select(p => new ProductImageDTO
                            {
                                Id = p.Id,
                                Filename = p.Filename,
                                Url = "https://wareship.blob.core.windows.net/images/" + p.Filename,
                                ProductId = p.ProductId,
                                CreatedAt = p.CreatedAt
                            }).ToList(),
                            Stocks = product.Stocks.Select(s => new StockDTO
                            {
                                Id = s.Id,
                                Sku = s.Sku,
                                Quantity = s.Quantity,
                                ProductId = s.ProductId,
                                OptionId = s.OptionId,
                                WarehouseId = s.WarehouseId,
                                CreatedAt = s.CreatedAt,
                                IsTrash = s.IsTrash
                            }).ToList(),
                        };

                        return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", productDTO));
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, ex.Message, null));
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "SubCategoryId did not exist", null));
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
