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
    [Route("api/zip_code")]
    [ApiController]
    public class Zip_CodeApiController : ControllerBase
    {
        private ApplicationDbContext database { get; }

        public Zip_CodeApiController(ApplicationDbContext context)
        {
            database = context;
        }

        [HttpGet]
        public IQueryable<Zip_Code> GetClasses()
        {
            return database.Zip_Codes.AsQueryable();
        }
    }
}