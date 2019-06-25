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

        /// <summary>
        /// Get all Loaned_Computers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable<Loaned_Computer> GetLoaned_Computers()
        {
            return database.Loaned_Computers.AsQueryable();
        }

        /// <summary>
        /// Get specific Loaned_Computer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Loaned_Computer GetLoaned_Computer(int id)
        {
            return database.Loaned_Computers.Single(lc => lc.Id == id);
        }

        /// <summary>
        /// Get a users Loaned_Computers
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        public IQueryable<Loaned_Computer> GetUsersLoaned_Computers(string userId)
        {
            return database.Loaned_Computers
                .Where(lc => lc.ApplicationUserId == userId)
                .Include(l => l.Computer);
        }

        /// <summary>
        /// Loan Computer
        /// </summary>
        /// <param name="loan"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReserveComputer([FromForm]NewLoan loan)
        {
            await database.Loaned_Computers.AddAsync(new Loaned_Computer
            {
                ComputerId = loan.ComputerId,
                ApplicationUserId = loan.UserId,
                Loaned_Date = loan.Loaned_Date,
                LoanExpiration_Date = loan.LoanExpiration_Date
            });

            await database.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLoaned_Computer), new { id = loan.ComputerId }, loan);
        }

        /// <summary>
        /// Remove Loaned_Computer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> CheckOutComputer (int id)
        {
            Loaned_Computer loaned = database.Loaned_Computers.Single(lc => lc.Id == id);

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