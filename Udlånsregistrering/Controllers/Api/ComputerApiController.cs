using Microsoft.AspNetCore.Mvc;
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
        public IQueryable<Computer> GetClasses()
        {
            return database.Computers.AsQueryable();
        }
    }
}
