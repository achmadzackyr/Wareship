using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wareship.Authentication;
using Wareship.Model.Transactions;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouriersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CouriersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Couriers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Courier>>> GetCourier()
        {
            return await _context.Courier.ToListAsync();
        }

        // GET: api/Couriers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Courier>> GetCourier(int id)
        {
            var courier = await _context.Courier.FindAsync(id);

            if (courier == null)
            {
                return NotFound();
            }

            return courier;
        }

        // PUT: api/Couriers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourier(int id, Courier courier)
        {
            if (id != courier.Id)
            {
                return BadRequest();
            }

            _context.Entry(courier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourierExists(id))
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

        // POST: api/Couriers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Courier>> PostCourier(Courier courier)
        {
            _context.Courier.Add(courier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourier", new { id = courier.Id }, courier);
        }

        // DELETE: api/Couriers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourier(int id)
        {
            var courier = await _context.Courier.FindAsync(id);
            if (courier == null)
            {
                return NotFound();
            }

            _context.Courier.Remove(courier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourierExists(int id)
        {
            return _context.Courier.Any(e => e.Id == id);
        }
    }
}
