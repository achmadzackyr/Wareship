using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wareship.Authentication;
using Wareship.Model.Users;
using Wareship.ViewModel.Auth;
using Wareship.ViewModel.Global;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _context;

        public SuppliersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        // GET: api/Suppliers
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSupplier()
        {
            var supplierList = 
                await _context.Supplier
                .Include(s => s.Address)
                .Include(s => s.CreatedBy)
                .Include(s => s.UserStatus)
                .Include(s => s.SubCategory)
                .ThenInclude(s => s.Category)
                .ToListAsync();
            var supplierDTOList = supplierList.Select(s => new SupplierDTO
            {
                Id = s.Id,
                Brand = s.Brand,
                Markup = s.Markup,
                Email = s.Email,
                CreatedAt = s.CreatedAt,
                CreatedAtString = s.CreatedAt.ToString("dd-MM-yyyy"),
                UpdatedAt = s.UpdatedAt,
                
                //Address
                AddressId = s.Address.Id,
                Name = s.Address.Name,
                Street = s.Address.Street,
                Province = s.Address.Province,
                ProvinceId = s.Address.ProvinceId,
                City = s.Address.City,
                CityId = s.Address.CityId,
                Subdistrict = s.Address.Subdistrict,
                SubdistrictId = s.Address.SubdistrictId,
                ZipCode = s.Address.ZipCode,
                Phone = s.Address.Phone,

                //Relation
                CategoryId = s.SubCategory.Category.Id,
                CategoryName = s.SubCategory.Category.Name,
                SubCategoryId = s.SubCategory.Id,
                SubCategoryName = s.SubCategory.Name,
                CreatedById = s.CreatedBy.Id,
                CreatedByName = s.CreatedBy.Name,
                UserStatusId = s.UserStatus.Id,
                UserStatusName = s.UserStatus.Name
            }).ToList();

            var response = GenerateListResponse(StatusCodes.Status200OK, "Success", supplierDTOList);
            return Ok(response);
        }

        // GET: api/Suppliers/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var s = await _context.Supplier
                .Where(p => p.Id == id)
                .Include(s => s.Address)
                .Include(s => s.CreatedBy)
                .Include(s => s.UserStatus)
                .Include(s => s.SubCategory)
                .ThenInclude(s => s.Category)
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Supplier Not Found", null));
            }
            var supplierDTO = new SupplierDTO
            {
                Id = s.Id,
                Brand = s.Brand,
                Markup = s.Markup,
                Email = s.Email,
                CreatedAt = s.CreatedAt,
                CreatedAtString = s.CreatedAt.ToString("dd-MM-yyyy"),
                UpdatedAt = s.UpdatedAt,

                //Address
                AddressId = s.Address.Id,
                Name = s.Address.Name,
                Street = s.Address.Street,
                Province = s.Address.Province,
                ProvinceId = s.Address.ProvinceId,
                City = s.Address.City,
                CityId = s.Address.CityId,
                Subdistrict = s.Address.Subdistrict,
                SubdistrictId = s.Address.SubdistrictId,
                ZipCode = s.Address.ZipCode,
                Phone = s.Address.Phone,

                //Relation
                CategoryId = s.SubCategory.Category.Id,
                CategoryName = s.SubCategory.Category.Name,
                SubCategoryId = s.SubCategory.Id,
                SubCategoryName = s.SubCategory.Name,
                CreatedById = s.CreatedBy.Id,
                CreatedByName = s.CreatedBy.Name,
                UserStatusId = s.UserStatus.Id,
                UserStatusName = s.UserStatus.Name
            };
            var response = GenerateResponse(StatusCodes.Status200OK, "Success", supplierDTO);
            return Ok(response);
        }

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, [FromBody] RegisterSupplierRequestModel request)
        {
            if (id != request.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest, GenerateResponse(StatusCodes.Status400BadRequest, "Supplier Id did not match with url", null));
            }
            try
            {
                var checkSupplier = await _context.Supplier.FindAsync(id);
                if(checkSupplier == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Supplier Not Found", null));
                } else
                {
                    _context.Entry(checkSupplier).State = EntityState.Detached;
                }

                var supplier = new Supplier
                {
                    Id = request.Id,
                    Brand = request.Brand,
                    Email = request.Email,
                    Markup = request.Markup,
                    UpdatedAt = DateTime.Now,
                    UserStatusId = request.UserStatusId,
                    SubCategoryId = request.SubCategoryId,

                    //unchangeable
                    AddressId = checkSupplier.AddressId,
                    CreatedAt = checkSupplier.CreatedAt,
                    CreatedById = checkSupplier.CreatedById
                };
                _context.Entry(supplier).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var provinceName = _context.Provinces.Find(request.ProvinceId).Name;
                var cityName = _context.Regencies.Find(request.CityId).Name;
                var subdistrictName = _context.SubDistricts.Find(request.SubdistrictId).Name;

                var address = new Address
                {
                    Id = checkSupplier.AddressId,
                    Name = request.Name,
                    Phone = request.PhoneNumber,
                    ProvinceId = request.ProvinceId,
                    Province = provinceName,
                    CityId = request.CityId,
                    City = cityName,
                    SubdistrictId = request.SubdistrictId,
                    Subdistrict = subdistrictName,
                    Street = request.Street,
                    ZipCode = request.ZipCode.ToString()
                };

                _context.Entry(address).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var s = await _context.Supplier
                .Where(p => p.Id == id)
                .Include(s => s.Address)
                .Include(s => s.CreatedBy)
                .Include(s => s.UserStatus)
                .Include(s => s.SubCategory)
                .ThenInclude(s => s.Category)
                .FirstOrDefaultAsync();

                var supplierDTO = new SupplierDTO
                {
                    Id = s.Id,
                    Brand = s.Brand,
                    Markup = s.Markup,
                    Email = s.Email,
                    CreatedAt = s.CreatedAt,
                    CreatedAtString = s.CreatedAt.ToString("dd-MM-yyyy"),
                    UpdatedAt = s.UpdatedAt,

                    //Address
                    AddressId = s.Address.Id,
                    Name = s.Address.Name,
                    Street = s.Address.Street,
                    Province = s.Address.Province,
                    ProvinceId = s.Address.ProvinceId,
                    City = s.Address.City,
                    CityId = s.Address.CityId,
                    Subdistrict = s.Address.Subdistrict,
                    SubdistrictId = s.Address.SubdistrictId,
                    ZipCode = s.Address.ZipCode,
                    Phone = s.Address.Phone,

                    //Relation
                    CategoryId = s.SubCategory.Category.Id,
                    CategoryName = s.SubCategory.Category.Name,
                    SubCategoryId = s.SubCategory.Id,
                    SubCategoryName = s.SubCategory.Name,
                    CreatedById = s.CreatedBy.Id,
                    CreatedByName = s.CreatedBy.Name,
                    UserStatusId = s.UserStatus.Id,
                    UserStatusName = s.UserStatus.Name
                };

                return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", supplierDTO));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Supplier Not Found", null));
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier([FromBody] RegisterSupplierRequestModel req)
        {
            if (ModelState.IsValid)
            {
                string Username = User.FindFirst(ClaimTypes.Name)?.Value;

                var user = await userManager.FindByNameAsync(Username);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, Username);
                }

                var provinceName = _context.Provinces.Find(req.ProvinceId).Name;
                var cityName = _context.Regencies.Find(req.CityId).Name;
                var subdistrictName = _context.SubDistricts.Find(req.SubdistrictId).Name;

                var address = new Address
                {
                    Name = req.Name,
                    CityId = req.CityId,
                    City = cityName,
                    ProvinceId = req.ProvinceId,
                    Province = provinceName,
                    Subdistrict = subdistrictName,
                    SubdistrictId = req.SubdistrictId,
                    Phone = req.PhoneNumber,
                    Street = req.Street,
                    ZipCode = req.ZipCode.ToString()
                };

                _context.Address.Add(address);
                await _context.SaveChangesAsync();

                var s = new Supplier
                {
                    AddressId = address.Id,
                    Brand = req.Brand,
                    CreatedAt = DateTime.Now,
                    CreatedById = user.Id,
                    Email = req.Email,
                    Markup = req.Markup,
                    SubCategoryId = req.SubCategoryId,
                    UserStatusId = 1
                };

                try
                {
                    _context.Supplier.Add(s);
                    await _context.SaveChangesAsync();

                    var subCategory = 
                        await _context.SubCategory
                        .Where(x => x.Id == s.SubCategoryId)
                        .Include(x => x.Category)
                        .FirstOrDefaultAsync();

                    var supplierDTO = new SupplierDTO
                    {
                        Id = s.Id,
                        Brand = s.Brand,
                        Markup = s.Markup,
                        Email = s.Email,
                        CreatedAt = s.CreatedAt,
                        CreatedAtString = s.CreatedAt.ToString("dd-MM-yyyy"),
                        UpdatedAt = s.UpdatedAt,

                        //Address
                        Name = address.Name,
                        Street = address.Street,
                        Province = address.Province,
                        ProvinceId = address.ProvinceId,
                        City = address.City,
                        CityId = address.CityId,
                        Subdistrict = address.Subdistrict,
                        SubdistrictId = address.SubdistrictId,
                        ZipCode = address.ZipCode,
                        Phone = address.Phone,

                        //Relation
                        CategoryId = subCategory.Category.Id,
                        CategoryName = subCategory.Category.Name,
                        SubCategoryId = s.SubCategoryId,
                        SubCategoryName = subCategory.Name,
                        CreatedById = s.CreatedById,
                        CreatedByName = user.UserName,
                        UserStatusId = s.UserStatusId,
                        UserStatusName = "Active"
                    };

                    return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", supplierDTO));
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

        // DELETE: api/Suppliers/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Supplier Not Found", null));
            }

            _context.Supplier.Remove(supplier);
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

        private bool SupplierExists(int id)
        {
            return _context.Supplier.Any(e => e.Id == id);
        }

        private SupplierListResponse GenerateListResponse(int statusCode, string message, List<SupplierDTO> response)
        {
            var stat = new Status();
            var resp = new SupplierListResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;

            return resp;
        }

        private SupplierResponse GenerateResponse(int statusCode, string message, SupplierDTO response)
        {
            var stat = new Status();
            var resp = new SupplierResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;

            return resp;
        }
    }
}
