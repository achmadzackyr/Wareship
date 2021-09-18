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
using Wareship.ViewModel.Category;
using Wareship.ViewModel.Global;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            var categoryList = await _context.Category.ToListAsync();
            var categoryDTOList = categoryList.Select(cat => new CategoryDTO
            {
                Id = cat.Id,
                Name = cat.Name,
                ThumbnailUrl = cat.ThumbnailUrl
            }).ToList();

            var response = GenerateListResponse(StatusCodes.Status200OK,"Success", categoryDTOList);
            return Ok(response);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var subCategories = await _context.SubCategory.Where(s => s.CategoryId == id).ToListAsync();
            var subCategoriesDTO = subCategories.Select(sub => new SubCategoryDTO
            {
                Id = sub.Id,
                Name = sub.Name,
                ThumbnailUrl = sub.ThumbnailUrl,
                CategoryId = sub.CategoryId
            }).ToList();

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Category Not Found", null));
            }

            var categoryDTO = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                ThumbnailUrl = category.ThumbnailUrl,
                SubCategories = subCategoriesDTO
            };

            var response = GenerateResponse(StatusCodes.Status200OK, "Success", categoryDTO);
            return Ok(response);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest, GenerateResponse(StatusCodes.Status400BadRequest, "Category Id Not Found", null));
            }

            _context.Entry(category).State = EntityState.Modified;
            var cat = await _context.Category.FindAsync(id);
            var catDTO = new CategoryDTO
            {
                Id = cat.Id,
                Name = cat.Name,
                ThumbnailUrl = cat.ThumbnailUrl
            };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Category Not Found", null));
                }
                else
                {
                    throw;
                }
            }
            return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", catDTO));
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] CategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var isExist = _context.Category.Any(e => e.Name == request.Name);
                if (isExist)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "Category Name Already Exist", null));
                }
                else
                {
                    Category cat = new()
                    {
                        Name = request.Name,
                        ThumbnailUrl = request.ThumbnailUrl
                    };

                    _context.Category.Add(cat);
                    var isSuccess = await _context.SaveChangesAsync();
                    if (isSuccess > 0)
                    {
                        var catDTO = new CategoryDTO
                        {
                            Id = cat.Id,
                            Name = cat.Name,
                            ThumbnailUrl = cat.ThumbnailUrl
                        };
                        return StatusCode(StatusCodes.Status201Created, GenerateResponse(StatusCodes.Status201Created, "Success", catDTO));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "Failed to add to database", null));
                    }
                }
            } else
            {
                return StatusCode(StatusCodes.Status400BadRequest, GenerateResponse(StatusCodes.Status400BadRequest, "Error", null));
            }

        }

        // DELETE: api/Categories/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Category Not Found", null));
            }

            _context.Category.Remove(category);
            var isSuccess = await _context.SaveChangesAsync();
            if(isSuccess > 0)
            {
                return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", null));
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "Failed to delete", null));
            }
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }

        private CategoryListResponse GenerateListResponse(int statusCode, string message, List<CategoryDTO> response)
        {
            var stat = new Status();
            var resp = new CategoryListResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;

            return resp;
        }

        private CategoryResponse GenerateResponse(int statusCode, string message, CategoryDTO response)
        {
            var stat = new Status();
            var resp = new CategoryResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;

            return resp;
        }
    }
}
