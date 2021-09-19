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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouse()
        {
            var warehouseList = await _context.Warehouse.ToListAsync();
            var warehouseDTOList = warehouseList.Select(w => new WarehouseDTO
            {
                Id = w.Id,
                Name = w.Name,
                City = w.City,
                Phone = w.Phone,
                Province = w.Province,
                Street = w.Street,
                Subdistrict = w.Subdistrict,
                ZipCode = w.ZipCode
            }).ToList();

            var response = GenerateListResponse(StatusCodes.Status200OK, "Success", warehouseDTOList);
            return Ok(response);
        }

        // GET: api/Warehouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
        {
            var w = await _context.Warehouse.FindAsync(id);

            if (w == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, GenerateResponse(StatusCodes.Status404NotFound, "Warehouse Not Found", null));
            }

            var warehouseDTO = new WarehouseDTO
            {
                Id = w.Id,
                Name = w.Name,
                City = w.City,
                Phone = w.Phone,
                Province = w.Province,
                Street = w.Street,
                Subdistrict = w.Subdistrict,
                ZipCode = w.ZipCode
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
                var warehouse = new Warehouse
                {
                    Id = request.Id,
                    Name = request.Name,
                    City = request.City,
                    Phone = request.Phone,
                    Province = request.Province,
                    Street = request.Street,
                    Subdistrict = request.Subdistrict,
                    ZipCode = request.ZipCode
                };

                _context.Entry(warehouse).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var warehouseDTO = new WarehouseDTO
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name,
                    City = warehouse.City,
                    Phone = warehouse.Phone,
                    Province = warehouse.Province,
                    Street = warehouse.Street,
                    Subdistrict = warehouse.Subdistrict,
                    ZipCode = warehouse.ZipCode
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
                var warehouse = new Warehouse
                {
                    Name = request.Name,
                    City = request.City,
                    Phone = request.Phone,
                    Province = request.Province,
                    Street = request.Street,
                    Subdistrict = request.Subdistrict,
                    ZipCode = request.ZipCode
                };

                try
                {
                    _context.Warehouse.Add(warehouse);
                    await _context.SaveChangesAsync();

                    var warehouseDTO = new WarehouseDTO
                    {
                        Id = warehouse.Id,
                        Name = warehouse.Name,
                        City = warehouse.City,
                        Phone = warehouse.Phone,
                        Province = warehouse.Province,
                        Street = warehouse.Street,
                        Subdistrict = warehouse.Subdistrict,
                        ZipCode = warehouse.ZipCode
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
