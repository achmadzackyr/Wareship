using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wareship.Authentication;
using Wareship.Model.Products;
using Wareship.Model.Stocks;
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

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {

            //var productList = await _context.Product.ToListAsync();
            var productList = await _context.Product.Include(p => p.ProductImages).ToListAsync();
            var productDTOList = productList.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ChargeableWeight = p.ChargeableWeight,
                Description = p.Description,
                Price = p.Price,
                Sku = p.Sku,
                Volume = p.Volume,
                Weight = p.Weight,
                UserId = p.UserId,
                ProductStatusId = p.ProductStatusId,
                ProductImages = p.ProductImages.Select(p => new ProductImageDTO
                {
                    Id = p.Id,
                    Url = p.Url,
                    ProductId = p.ProductId,
                    CreatedAt = p.CreatedAt
                }).ToList()
            }).ToList();

            var response = GenerateListResponse(StatusCodes.Status200OK, "Success", productDTOList);
            return Ok(response);
        }

        private List<StockDTO> GetProductStock(int productId)
        {
            var productStockList = _context.Stock
                .Where(p => p.ProductId == productId)
                .Select(p => new StockDTO
                {
                    Id = p.Id,
                    Sku = p.Sku,
                    Quantity = p.Quantity,
                    ProductId = p.ProductId,
                    CreatedAt = p.CreatedAt
                    //Option = GetProductOption(p.OptionId),
                    //Warehouse = GetProductWarehouse(p.WarehouseId),
                })
                .ToList();
            return productStockList;
        }

        private WarehouseDTO GetProductWarehouse(int warehouseId)
        {
            var warehouse = _context.Warehouse
                .Where(p => p.Id == warehouseId)
                .Select(w => new WarehouseDTO
                {
                    Id = w.Id,
                    Name = w.Name,
                    City = w.City,
                    Phone = w.Phone,
                    Province = w.Province,
                    Street = w.Street,
                    Subdistrict = w.Subdistrict,
                    ZipCode = w.ZipCode
                })
                .FirstOrDefault();
            return warehouse;
        }

        private OptionDTO GetProductOption(int optionId)
        {
            var option = _context.Option
                .Where(p => p.Id == optionId)
                .Select(p => new OptionDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Variation = GetOptionVariation(p.VariationId)
                })
                .FirstOrDefault();
            return option;
        }

        private VariationDTO GetOptionVariation(int variationId)
        {
            var variation = _context.Variation
                .Where(p => p.Id == variationId)
                .Select(p => new VariationDTO
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .FirstOrDefault();
            return variation;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var p = await _context.Product
                .Include(p => p.ProductImages)
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
                PriceString = "Rp"+ p.Price.ToString("N0").Replace(',', '.'),
                Sku = p.Sku,
                Volume = p.Volume,
                Weight = p.Weight,
                UserId = p.UserId,
                User = new UserDTO
                {
                    City = p.User.City,
                    Name = p.User.Name,
                    Phone = p.User.Phone,
                    ProfilePictureUrl = p.User.ProfilePictureUrl,
                    Province = p.User.Province,
                    Street = p.User.Street,
                    Subdistrict = p.User.Subdistrict,
                    ZipCode = p.User.ZipCode
                },
                ProductStatusId = p.ProductStatusId,
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
                    Url = p.Url,
                    ProductId = p.ProductId,
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
                        Name = p.Warehouse.Name,
                        City = p.Warehouse.City,
                        Subdistrict = p.Warehouse.Subdistrict,
                        Phone = p.Warehouse.Phone,
                        Province = p.Warehouse.Province,
                        Street = p.Warehouse.Street,
                        ZipCode = p.Warehouse.ZipCode
                    }
                })
                .ToList()
            };

            var response = GenerateResponse(StatusCodes.Status200OK, "Success", productDTO);
            return Ok(response);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] ProductRequest request)
        {
            if (id != request.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest, GenerateResponse(StatusCodes.Status400BadRequest, "Product Id did not match with url", null));
            }

            try
            {
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

                //delete all current image
                var currentImageList = await _context
                    .ProductImage.Where(im => im
                    .ProductId == product.Id)
                    .ToListAsync();

                foreach (var currentImage in currentImageList)
                {
                    _context.ProductImage.Remove(currentImage);
                    await _context.SaveChangesAsync();
                }

                //add new image
                foreach(var imgUrl in request.ImageUrl)
                {
                    var productImage = new ProductImage
                    {
                        ProductId = product.Id,
                        CreatedAt = DateTime.Now,
                        Url = imgUrl
                    };

                    _context.ProductImage.Add(productImage);
                    await _context.SaveChangesAsync();
                }
                

                var p = await _context.Product
                    .Include(p => p.ProductImages)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                var subCat = await _context.SubCategory
                    .Where(s => s.Id == p.SubCategoryId)
                    .FirstOrDefaultAsync();

                var cat = await _context.Category
                    .Where(s => s.Id == subCat.CategoryId)
                    .FirstOrDefaultAsync();

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
                    ProductStatusId = p.ProductStatusId,
                    ProductImages = p.ProductImages.Select(p => new ProductImageDTO
                    {
                        Id = p.Id,
                        Url = p.Url,
                        ProductId = p.ProductId,
                        CreatedAt = p.CreatedAt
                    }).ToList(),
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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] ProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var sub = await _context.SubCategory.FindAsync(request.SubCategoryId);
                if(sub != null)
                {
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
                        ProductStatusId = 1,
                        SubCategoryId = request.SubCategoryId
                    };
                    try
                    {
                        _context.Product.Add(product);
                        await _context.SaveChangesAsync();

                        //add new image
                        foreach (var imgUrl in request.ImageUrl)
                        {
                            var productImage = new ProductImage
                            {
                                ProductId = product.Id,
                                CreatedAt = DateTime.Now,
                                Url = imgUrl
                            };

                            //_context.Entry(productImage).State = EntityState.Modified;
                            _context.ProductImage.Add(productImage);
                            await _context.SaveChangesAsync();
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
                                CreatedAt = DateTime.Now,
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
                                Url = p.Url,
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
                    catch
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "Failed to add to database", null));
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
        [Authorize]
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
