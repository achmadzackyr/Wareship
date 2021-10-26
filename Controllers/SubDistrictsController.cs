using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wareship.Authentication;
using Wareship.Model.Indonesia;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDistrictsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubDistrictsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubDistricts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubDistricts>>> GetSubDistrict()
        {
            return await _context.SubDistricts.ToListAsync();
        }

        // GET: api/SubDistricts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubDistricts>> GetSubDistrict(string id)
        {
            var subDistrict = await _context.SubDistricts.FindAsync(id);

            if (subDistrict == null)
            {
                return NotFound();
            }

            return subDistrict;
        }

        // PUT: api/SubDistricts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubDistrict(string id, SubDistricts subDistrict)
        {
            if (id != subDistrict.Id)
            {
                return BadRequest();
            }

            _context.Entry(subDistrict).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubDistrictExists(id))
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

        // POST: api/SubDistricts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubDistricts>> PostSubDistrict(SubDistricts subDistrict)
        {
            _context.SubDistricts.Add(subDistrict);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubDistrictExists(subDistrict.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubDistrict", new { id = subDistrict.Id }, subDistrict);
        }

        // DELETE: api/SubDistricts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubDistrict(string id)
        {
            var subDistrict = await _context.SubDistricts.FindAsync(id);
            if (subDistrict == null)
            {
                return NotFound();
            }

            _context.SubDistricts.Remove(subDistrict);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubDistrictExists(string id)
        {
            return _context.SubDistricts.Any(e => e.Id == id);
        }
    }
}
