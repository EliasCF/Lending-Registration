using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udlånsregistrering.Data;
using Udlånsregistrering.Models;

namespace Udlånsregistrering.Controllers.Api
{
    [Route("api/city")]
    [ApiController]
    public class CityApiController : ControllerBase
    {
        private ApplicationDbContext database { get; }

        public CityApiController(ApplicationDbContext context)
        {
            database = context;
        }

        [HttpGet]
        public IQueryable<City> GetClasses()
        {
            return database.Cities.AsQueryable();
        }
    }
}