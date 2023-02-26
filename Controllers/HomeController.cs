using Kirtland_Artist_Guild.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kirtland_Artist_Guild.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Artists()
        {
            return View();
        }

        public IActionResult About_Us()
        {
            return View();
        }

        public IActionResult Exhibitions()
        {
            return View();
        }

        public IActionResult Artistic_Style()
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