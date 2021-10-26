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
    public class RegenciesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Regencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Regencies>>> GetRegencies()
        {
            return await _context.Regencies.ToListAsync();
        }

        // GET: api/Regencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Regencies>> GetRegencies(string id)
        {
            var regencies = await _context.Regencies.FindAsync(id);

            if (regencies == null)
            {
                return NotFound();
            }

            return regencies;
        }

        // PUT: api/Regencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegencies(string id, Regencies regencies)
        {
            if (id != regencies.Id)
            {
                return BadRequest();
            }

            _context.Entry(regencies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegenciesExists(id))
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

        // POST: api/Regencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Regencies>> PostRegencies(Regencies regencies)
        {
            _context.Regencies.Add(regencies);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegenciesExists(regencies.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegencies", new { id = regencies.Id }, regencies);
        }

        // DELETE: api/Regencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegencies(string id)
        {
            var regencies = await _context.Regencies.FindAsync(id);
            if (regencies == null)
            {
                return NotFound();
            }

            _context.Regencies.Remove(regencies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegenciesExists(string id)
        {
            return _context.Regencies.Any(e => e.Id == id);
        }
    }
}
