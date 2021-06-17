using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Data;
using LeaveManagement.Models;

namespace LeaveManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserLeaveController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserLeaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /UserLeaveControllers/GetAllUsersLeaves
        [HttpGet("GetAllUsersLeaves")]
        public async Task<ActionResult<IEnumerable<UserLeave>>> GetAllUsersLeaves()
        {
            return await _context.UserLeaves.Where(x => x.IsActive == 1).ToListAsync();
        }

        // GET: /UserLeaveControllers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLeave>> GetUserLeave(int id)
        {
            var userLeave = await _context.UserLeaves.FindAsync(id);

            if (userLeave == null)
            {
                return NotFound();
            }

            return userLeave;
        }

        // GET: /UserLeaveControllers/GetUserLeaves/{userId}
        [HttpGet("GetUserLeaves/{userID}")]
        public async Task<ActionResult<IEnumerable<UserLeave>>> GetUserLeaves(string userID)
        {
            var userLeaves = await _context.UserLeaves.Where(x => x.ApplicationUserId == userID && x.IsActive == 1).ToListAsync();

            if (userLeaves == null)
            {
                return NotFound();
            }

            return userLeaves;
        }

        // GET: /UserLeave/GetUserLeaveBalance/{userId}
        [HttpGet("GetUserLeaveBalance/{userID}")]
        public async Task<ActionResult<decimal>> GetUserLeaveBalance(string userID)
        {
            ApplicationUser user = await _context.ApplicationUsers.FindAsync(userID);

            return user.LeaveBalance;
        }

        // PUT: /UserLeave/PutUserLeave/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLeave(int id, UserLeave userLeave)
        {
            if (id != userLeave.ID)
            {
                return BadRequest();
            }

            _context.Entry(userLeave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLeaveExists(id))
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

        // POST: /UserLeave
        [HttpPost]
        public async Task<ActionResult<UserLeave>> PostUserLeave(UserLeave userLeave)
        {
            ApplicationUser user = await _context.ApplicationUsers.FindAsync(userLeave.ApplicationUserId);

            userLeave.RemainingLeaveBalance = user.LeaveBalance - userLeave.Duration;

            user.LeaveBalance = userLeave.RemainingLeaveBalance;

            _context.UserLeaves.Add(userLeave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLeave", new { id = userLeave.ID }, userLeave);
        }


        // DELETE: /UserLeaveControllers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserLeave>> DeleteUserLeave(int id)
        {
            var userLeave = await _context.UserLeaves.FindAsync(id);
            if (userLeave == null)
            {
                return NotFound();
            }

            _context.UserLeaves.Remove(userLeave);
            await _context.SaveChangesAsync();

            return userLeave;
        }

        private bool UserLeaveExists(int id)
        {
            return _context.UserLeaves.Any(e => e.ID == id);
        }
    }
}
