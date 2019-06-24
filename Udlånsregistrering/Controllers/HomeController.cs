using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Udlånsregistrering.Models;

namespace Udlånsregistrering.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> manager { get; }

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            manager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Student()
        {
            string userId = manager.GetUserId(HttpContext.User);

            return View("Student", userId);
        }

        [Authorize]
        public IActionResult Teacher()
        {
            return View();
        }

        [Authorize]
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
