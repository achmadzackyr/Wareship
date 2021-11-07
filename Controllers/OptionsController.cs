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
    public class OptionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Options
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Option>>> GetOption()
        {
            return await _context.Option.ToListAsync();
        }

        // GET: api/Options/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Option>> GetOption(int id)
        {
            var option = await _context.Option.FindAsync(id);

            if (option == null)
            {
                return NotFound();
            }

            return option;
        }

        // PUT: api/Options/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOption(int id, Option option)
        {
            if (id != option.Id)
            {
                return BadRequest();
            }

            _context.Entry(option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
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

        // POST: api/Options
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult<Option>> PostOption(Option option)
        {
            _context.Option.Add(option);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOption", new { id = option.Id }, option);
        }

        // DELETE: api/Options/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var option = await _context.Option.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }

            _context.Option.Remove(option);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionExists(int id)
        {
            return _context.Option.Any(e => e.Id == id);
        }
    }
}
