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
    [Route("api/class")]
    [ApiController]
    public class ClassApiController : ControllerBase
    {
        private ApplicationDbContext database { get; }

        public ClassApiController (ApplicationDbContext context)
        {
            database = context;
        }

        [HttpGet]
        public IQueryable<Class> GetClasses ()
        {
            return database.Classes.AsQueryable();
        }
    }
}