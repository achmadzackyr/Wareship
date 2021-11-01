using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wareship.Authentication;
using Wareship.Model.Users;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserStatus
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStatus>>> GetUserStatus()
        {
            return await _context.UserStatus.ToListAsync();
        }

        // GET: api/UserStatus/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStatus>> GetUserStatus(int id)
        {
            var userStatus = await _context.UserStatus.FindAsync(id);

            if (userStatus == null)
            {
                return NotFound();
            }

            return userStatus;
        }

        // PUT: api/UserStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStatus(int id, UserStatus userStatus)
        {
            if (id != userStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(userStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStatusExists(id))
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

        // POST: api/UserStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult<UserStatus>> PostUserStatus(UserStatus userStatus)
        {
            _context.UserStatus.Add(userStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserStatus", new { id = userStatus.Id }, userStatus);
        }

        // DELETE: api/UserStatus/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStatus(int id)
        {
            var userStatus = await _context.UserStatus.FindAsync(id);
            if (userStatus == null)
            {
                return NotFound();
            }

            _context.UserStatus.Remove(userStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserStatusExists(int id)
        {
            return _context.UserStatus.Any(e => e.Id == id);
        }
    }
}
