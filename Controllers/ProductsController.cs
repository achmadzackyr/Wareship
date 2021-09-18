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
using Wareship.ViewModel.Global;
using Wareship.ViewModel.Product;

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

            var productList = await _context.Product.ToListAsync();
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
                SubCategoryId = p.SubCategoryId,
                ProductImages = GetProductImage(p.Id)
            }).ToList();

            var response = GenerateListResponse(StatusCodes.Status200OK, "Success", productDTOList);
            return Ok(response);
        }

        private List<ProductImageDTO> GetProductImage(int productId)
        {
            var productImageList = _context.ProductImage
                .Where(p => p.ProductId == productId)
                .Select(p => new ProductImageDTO
                {
                    Id = p.Id,
                    Url = p.Url,
                    ProductId = p.ProductId,
                    CreatedAt = p.CreatedAt
                })
                .ToList();
            return productImageList;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var p = await _context.Product.FindAsync(id);

            if (p == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Product Not Found", null));
            }

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
                PriceString = "Rp"+ p.Price.ToString("N0").Replace(',', '.'),
                Sku = p.Sku,
                Volume = p.Volume,
                Weight = p.Weight,
                UserId = p.UserId,
                ProductStatusId = p.ProductStatusId,
                SubCategoryId = p.SubCategoryId,
                ProductImages = GetProductImage(p.Id),
                CategoryName = cat.Name,
                SubCategoryName = subCat.Name
            };

            var response = GenerateResponse(StatusCodes.Status200OK, "Success", productDTO);
            return Ok(response);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
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

                    //_context.Entry(productImage).State = EntityState.Modified;
                    _context.ProductImage.Add(productImage);
                    await _context.SaveChangesAsync();
                }
                

                var p = await _context.Product.FindAsync(id);
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
                    SubCategoryId = p.SubCategoryId,
                    ProductImages = GetProductImage(p.Id),
                    CategoryName = cat.Name,
                    SubCategoryName = subCat.Name
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
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
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
