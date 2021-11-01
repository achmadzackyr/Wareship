using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wareship.Authentication;
using Wareship.Model.Indonesia;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProvincesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Provinces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provinces>>> GetProvinces()
        {
            return await _context.Provinces.ToListAsync();
        }

        // GET: api/Provinces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provinces>> GetProvinces(string id)
        {
            var provinces = await _context.Provinces.FindAsync(id);

            if (provinces == null)
            {
                return NotFound();
            }

            return provinces;
        }

        // PUT: api/Provinces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvinces(string id, Provinces provinces)
        {
            if (id != provinces.Id)
            {
                return BadRequest();
            }

            _context.Entry(provinces).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvincesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Provinces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult<Provinces>> PostProvinces(Provinces provinces)
        {
            _context.Provinces.Add(provinces);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProvincesExists(provinces.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProvinces", new { id = provinces.Id }, provinces);
        }

        // DELETE: api/Provinces/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvinces(string id)
        {
            var provinces = await _context.Provinces.FindAsync(id);
            if (provinces == null)
            {
                return NotFound();
            }

            _context.Provinces.Remove(provinces);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvincesExists(string id)
        {
            return _context.Provinces.Any(e => e.Id == id);
        }
    }
}
