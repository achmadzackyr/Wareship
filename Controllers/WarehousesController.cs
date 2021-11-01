using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wareship.Authentication;
using Wareship.Model.Stocks;
using Wareship.Model.Users;
using Wareship.ViewModel.Global;
using Wareship.ViewModel.Warehouse;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WarehousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Warehouses
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouse()
        {
            var warehouseList = await _context.Warehouse.ToListAsync();
            var wList = await _context.Warehouse
                .Include(w => w.Address)
                .AsSplitQuery()
                .OrderBy(w => w.Id)
                .ToListAsync();

            var warehouseDTOList = warehouseList.Select(wList => new WarehouseDTO
            {
                Id = wList.Id,
                Name = wList.Address.Name,
                CityId = wList.Address.CityId,
                City = wList.Address.City,
                Phone = wList.Address.Phone,
                ProvinceId = wList.Address.ProvinceId,
                Province = wList.Address.Province,
                Street = wList.Address.Street,
                SubdistrictId = wList.Address.SubdistrictId,
                Subdistrict = wList.Address.Subdistrict,
                ZipCode = wList.Address.ZipCode
            }).ToList();

            var response = GenerateListResponse(StatusCodes.Status200OK, "Success", warehouseDTOList);
            return Ok(response);
        }

        // GET: api/Warehouses/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
        {
            var w = await _context.Warehouse
                .Include(w => w.Address)
                .AsSplitQuery()
                .OrderBy(w => w.Id)
                .SingleAsync(w => w.Id == id);

            if (w == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Warehouse Not Found", null));
            }

            var warehouseDTO = new WarehouseDTO
            {
                Id = w.Id,
                Name = w.Address.Name,
                CityId = w.Address.CityId,
                City = w.Address.City,
                Phone = w.Address.Phone,
                ProvinceId = w.Address.ProvinceId,
                Province = w.Address.Province,
                Street = w.Address.Street,
                SubdistrictId = w.Address.SubdistrictId,
                Subdistrict = w.Address.Subdistrict,
                ZipCode = w.Address.ZipCode
            };

            var response = GenerateResponse(StatusCodes.Status200OK, "Success", warehouseDTO);
            return Ok(response);
        }

        // PUT: api/Warehouses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarehouse(int id, [FromBody] WarehouseRequest request)
        {
            if (id != request.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest, GenerateResponse(StatusCodes.Status400BadRequest, "Warehouse Id did not match with url", null));
            }


            try
            {
                var w = await _context.Warehouse.FindAsync(id);

                var provinceName = _context.Provinces.Find(request.ProvinceId).Name;
                var cityName = _context.Regencies.Find(request.CityId).Name;
                var subdistrictName = _context.SubDistricts.Find(request.SubdistrictId).Name;

                var address = new Address
                {
                    Id = w.AddressId,
                    Name = request.Name,
                    CityId = request.CityId,
                    City = cityName,
                    Phone = request.Phone,
                    ProvinceId = request.ProvinceId,
                    Province = provinceName,
                    Street = request.Street,
                    SubdistrictId = request.SubdistrictId,
                    Subdistrict = subdistrictName,
                    ZipCode = request.ZipCode
                };

                _context.Entry(address).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var warehouseDTO = new WarehouseDTO
                {
                    Id = w.Id,
                    Name = address.Name,
                    City = address.City,
                    Phone = address.Phone,
                    Province = address.Province,
                    Street = address.Street,
                    Subdistrict = address.Subdistrict,
                    ZipCode = address.ZipCode
                };
                return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", warehouseDTO));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseExists(id))
                {
                    return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Warehouse Not Found", null));
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Warehouses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult<Warehouse>> PostWarehouse([FromBody] WarehouseRequest request)
        {
            if (ModelState.IsValid)
            {
                var provinceName = _context.Provinces.Find(request.ProvinceId).Name;
                var cityName = _context.Regencies.Find(request.CityId).Name;
                var subdistrictName = _context.SubDistricts.Find(request.SubdistrictId).Name;

                var address = new Address
                {
                    Name = request.Name,
                    CityId = request.CityId,
                    City = cityName,
                    Phone = request.Phone,
                    ProvinceId = request.ProvinceId,
                    Province = provinceName,
                    Street = request.Street,
                    SubdistrictId = request.SubdistrictId,
                    Subdistrict = subdistrictName,
                    ZipCode = request.ZipCode
                };

                _context.Address.Add(address);
                await _context.SaveChangesAsync();

                var warehouse = new Warehouse
                {
                    AddressId = address.Id
                };

                try
                {
                    _context.Warehouse.Add(warehouse);
                    await _context.SaveChangesAsync();

                    var warehouseDTO = new WarehouseDTO
                    {
                        Id = warehouse.Id,
                        Name = address.Name,
                        CityId = address.CityId,
                        City = address.City,
                        Phone = address.Phone,
                        ProvinceId = address.ProvinceId,
                        Province = address.Province,
                        Street = address.Street,
                        SubdistrictId = address.SubdistrictId,
                        Subdistrict = address.Subdistrict,
                        ZipCode = address.ZipCode
                    };

                    return Ok(GenerateResponse(StatusCodes.Status200OK, "Success", warehouseDTO));
                }
                catch
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponse(StatusCodes.Status500InternalServerError, "Failed to add to database", null));
                }
            } else
            {
                return StatusCode(StatusCodes.Status400BadRequest, GenerateResponse(StatusCodes.Status400BadRequest, "Error", null));
            }
        }

        // DELETE: api/Warehouses/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            var warehouse = await _context.Warehouse.FindAsync(id);
            if (warehouse == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Warehouse Not Found", null));
            }

            _context.Warehouse.Remove(warehouse);
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

        private bool WarehouseExists(int id)
        {
            return _context.Warehouse.Any(e => e.Id == id);
        }

        private WarehouseListResponse GenerateListResponse(int statusCode, string message, List<WarehouseDTO> response)
        {
            var stat = new Status();
            var resp = new WarehouseListResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;

            return resp;
        }

        private WarehouseResponse GenerateResponse(int statusCode, string message, WarehouseDTO response)
        {
            var stat = new Status();
            var resp = new WarehouseResponse();

            stat.ResponseCode = statusCode;
            stat.ResponseMessage = message;

            resp.Status = stat;
            resp.Result = response;

            return resp;
        }
    }
}
