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
    public class LeaveReasonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeaveReasonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveReason
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveReason>>> GetLeaveReason()
        {
            return await _context.LeaveReasons.ToListAsync();
        }

        private bool LeaveReasonExists(int id)
        {
            return _context.LeaveReasons.Any(e => e.Id == id);
        }
    }
}
