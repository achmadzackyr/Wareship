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
    public class SubCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategory()
        {
            var subCategoryList = await _context.SubCategory.ToListAsync();
            var subCategoryDTOList = subCategoryList.Select(cat => new SubCategoryDTO
            {
                Id = cat.Id,
                CategoryId = cat.CategoryId,
                Name = cat.Name,
                ThumbnailUrl = cat.ThumbnailUrl
            }).ToList();

            var response = GenerateListResponse(StatusCodes.Status200OK, "Success", subCategoryDTOList);
            return Ok(response);
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategory>> GetSubCategory(int id)
        {
            var subCategory = await _context.SubCategory.FindAsync(id);

            if (subCategory == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "SubCategory Not Found", null));
            }

            var subCategoryDTO = new SubCategoryDTO
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                ThumbnailUrl = subCategory.ThumbnailUrl,
                CategoryId = subCategory.CategoryId
            };

            var response = GenerateResponse(StatusCodes.Status200OK, "Success", subCategoryDTO);
            return Ok(response);
        }

        // PUT: api/SubCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategory(int id, SubCategory subCategory)
        {
            if (id != subCategory.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest, GenerateResponse(StatusCodes.Status400BadRequest, "SubCategory Id Not Found", null));
            }

            _context.Entry(subCategory).State = EntityState.Modified;
            var subCat = await _context.SubCategory.FindAsync(id);
            var subCatDTO = new SubCategoryDTO
            {
                Id = subCat.Id,
                Name = subCat.Name,
                ThumbnailUrl = subCat.ThumbnailUrl,
                CategoryId = subCat.CategoryId
            };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(id))
                {
                    return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "SubCategory Not Found", null));
                }
                else
                {
                    throw;
                }
            }

            return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", subCatDTO));
        }

        // POST: api/SubCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult<SubCategory>> PostSubCategory([FromBody] SubCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var cat = await _context.Category.FindAsync(request.CategoryId);
                if(cat != null)
                {
                    var isExist = _context.SubCategory.Any(e => e.Name == request.Name);
                    if (isExist)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "SubCategory Name Already Exist", null));
                    }
                    else
                    {
                        SubCategory sub = new()
                        {
                            Name = request.Name,
                            ThumbnailUrl = request.ThumbnailUrl,
                            CategoryId = request.CategoryId
                        };

                        _context.SubCategory.Add(sub);
                        var isSuccess = await _context.SaveChangesAsync();
                        if (isSuccess > 0)
                        {
                            var subCatDTO = new SubCategoryDTO
                            {
                                Id = sub.Id,
                                Name = sub.Name,
                                ThumbnailUrl = sub.ThumbnailUrl,
                                CategoryId = sub.CategoryId
                            };
                            return StatusCode(StatusCodes.Status201Created, GenerateResponse(StatusCodes.Status201Created, "Success", subCatDTO));
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "Failed to add to database", null));
                        }
                    }
                } else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "CategoryId did not exist", null));
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, GenerateResponse(StatusCodes.Status400BadRequest, "Error", null));
            }
        }

        // DELETE: api/SubCategories/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var subCategory = await _context.SubCategory.FindAsync(id);
            if (subCategory == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "SubCategory Not Found", null));
            }

            _context.SubCategory.Remove(subCategory);
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

        private bool SubCategoryExists(int id)
        {
            return _context.SubCategory.Any(e => e.Id == id);
        }

        private SubCategoryListResponse GenerateListResponse(int statusCode, string message, List<SubCategoryDTO> response)
        {
            var stat = new Status();
            var resp = new SubCategoryListResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;

            return resp;
        }

        private SubCategoryResponse GenerateResponse(int statusCode, string message, SubCategoryDTO response)
        {
            var stat = new Status();
            var resp = new SubCategoryResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;

            return resp;
        }
    }
}
