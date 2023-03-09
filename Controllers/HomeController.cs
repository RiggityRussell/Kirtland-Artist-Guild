using Kirtland_Artist_Guild.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kirtland_Artist_Guild.Controllers
{
    public class HomeController : Controller
    {
        private readonly StoreContext _context;

        public HomeController(StoreContext context)
        {
            _context = context;
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

        public async Task<IActionResult> Artistic_Style()
        {
            ArtisticStyleViewModel model = new ArtisticStyleViewModel();
            model.ArtColors = await _context.ArtColors.ToListAsync();
            model.ArtMediums = await _context.ArtMediums.ToListAsync();
            model.ArtStyles = await _context.ArtStyles.ToListAsync();

            model.Arts = await _context.Arts.ToListAsync();
            model.ArtImages = await _context.ArtImages.ToListAsync();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}