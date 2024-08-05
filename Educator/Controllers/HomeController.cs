using Educator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Educator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult Climate_change()
        {
            return View();
        }
        [Authorize]
        public IActionResult Bio_diversity()
        {
            return View();
        }
        [Authorize]
        public IActionResult Renewable_energy()
        {
            return View();
        }
        [Authorize]
        public IActionResult Waste_management()
        {
            return View();
        }
        [Authorize]
        public IActionResult Sustainable_living()
        {
            return View();
        }
        [Authorize]
        public IActionResult Conservation()
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