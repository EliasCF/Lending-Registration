using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Udlånsregistrering.Data;
using Udlånsregistrering.Models;

namespace Udlånsregistrering.Controllers.Api
{
    [Route("api/computer")]
    [ApiController]
    public class ComputerApiController : Controller
    {
        private ApplicationDbContext database { get; }

        public ComputerApiController(ApplicationDbContext context)
        {
            database = context;
        }

        [HttpGet]
        public IQueryable<Computer> GetComputers()
        {
            return database.Computers.AsQueryable();
        }

        [HttpGet("{id}")]
        public Computer GetComputer (int id)
        {
            return database.Computers.Single(c => c.Id == id);
        }

        [HttpGet("unreserved")]
        public IQueryable<Computer> GetUnreserved ()
        {
            return database.Computers
                .Where(c => !database.Loaned_Computers.Any(lc => lc.ComputerId == c.Id))
                .Include(c => c.Mouse)
                    .ThenInclude(m => m.Brand)
                .Include(c => c.Model)
                    .ThenInclude(m => m.Brand);
        }
    }
}
