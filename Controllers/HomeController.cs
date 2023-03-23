using Kirtland_Artist_Guild.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kirtland_Artist_Guild.Controllers
{
    [AllowAnonymous]
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

        public async Task<IActionResult> Artistic_Style(int colorFilter = 0, int mediumFilter = 0, int styleFilter = 0)
        {
            ArtisticStyleViewModel model = new ArtisticStyleViewModel();
            ViewData["CurrentColorFilter"] = colorFilter;
            ViewData["CurrentMediumFilter"] = mediumFilter;
            ViewData["CurrentStyleFilter"] = styleFilter;

            model.ArtColors = await _context.ArtColors.ToListAsync();
            model.ArtMediums = await _context.ArtMediums.ToListAsync();
            model.ArtStyles = await _context.ArtStyles.ToListAsync();
            model.ArtImages = await _context.ArtImages.ToListAsync();
            var arts = from a in _context.Arts select a;


            /*if (colorFilter == 0) { 
                model.Arts = await _context.Arts.ToListAsync(); 
            }
            else { 
                model.Arts = await _context.Arts.Where(a => a.ArtColorLinks.Any(c => c.ArtColorID == colorFilter)).ToListAsync();                
            }*/

            if (colorFilter != 0)
            {
                arts = arts.Where(a => a.ArtColorLinks.Any(c => c.ArtColorID == colorFilter));
            }
            if (mediumFilter != 0)
            {
                arts = arts.Where(a => a.ArtMediumLinks.Any(c => c.ArtMediumID == mediumFilter));
            }
            if (styleFilter != 0)
            {
                arts = arts.Where(a => a.ArtStyleLinks.Any(c => c.ArtStyleID == styleFilter));
            }

            model.Arts = await arts.ToListAsync();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}