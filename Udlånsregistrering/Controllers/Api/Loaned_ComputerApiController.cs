using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Udlånsregistrering.Data;
using Udlånsregistrering.Models;

namespace Udlånsregistrering.Controllers.Api
{
    [Route("api/loanedComputer")]
    [ApiController]
    public class Loaned_ComputerApiController : ControllerBase
    {
        private ApplicationDbContext database { get; }

        public Loaned_ComputerApiController(ApplicationDbContext context)
        {
            database = context;
        }

        [HttpGet]
        public IQueryable<Loaned_Computer> GetLoaned_Computers()
        {
            return database.Loaned_Computers.AsQueryable();
        }

        [HttpGet("{userId}")]
        public IQueryable<Loaned_Computer> GetUsersLoaned_Computers(string userId)
        {
            return database.Loaned_Computers
                .Where(lc => lc.ApplicationUserId == userId)
                .Include(l => l.Computer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CheckOutComputer (int id)
        {
            Loaned_Computer loaned = new Loaned_Computer { Id = id };

            if (loaned == null)
            {
                return NotFound();
            }

            database.Loaned_Computers.Attach(loaned);
            database.Loaned_Computers.Remove(loaned);

            await database.SaveChangesAsync();

            return NoContent();
        }
    }
}