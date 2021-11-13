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

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VariationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Variations
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Variation>>> GetVariation()
        {
            return await _context.Variation.ToListAsync();
        }

        // GET: api/Variations/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Variation>> GetVariation(int id)
        {
            var variation = await _context.Variation.FindAsync(id);

            if (variation == null)
            {
                return NotFound();
            }

            return variation;
        }

        // GET: api/Variations/5/options
        [Authorize]
        [HttpGet("{id}/options")]
        public async Task<ActionResult<IEnumerable<Option>>> GetVariationOptions(int id)
        {
            var options = await _context.Option.Where(v => v.VariationId == id).ToListAsync();
            if (options == null)
            {
                return NotFound();
            }

            return options;
        }

        // PUT: api/Variations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariation(int id, Variation variation)
        {
            if (id != variation.Id)
            {
                return BadRequest();
            }

            _context.Entry(variation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VariationExists(id))
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

        // POST: api/Variations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult<Variation>> PostVariation(Variation variation)
        {
            _context.Variation.Add(variation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariation", new { id = variation.Id }, variation);
        }

        // DELETE: api/Variations/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariation(int id)
        {
            var variation = await _context.Variation.FindAsync(id);
            if (variation == null)
            {
                return NotFound();
            }

            _context.Variation.Remove(variation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VariationExists(int id)
        {
            return _context.Variation.Any(e => e.Id == id);
        }
    }
}
