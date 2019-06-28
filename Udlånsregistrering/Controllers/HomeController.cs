using System.Diagnostics;
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
            return Redirect("Identity/Account/Login");
        }

        [Authorize(Roles = "Student")]
        public IActionResult Student()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Teacher()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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
