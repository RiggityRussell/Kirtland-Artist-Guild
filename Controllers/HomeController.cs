﻿using Kirtland_Artist_Guild.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace Kirtland_Artist_Guild.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly StoreContext _context;
        private UserManager<User> userManager;

        public HomeController(StoreContext context, UserManager<User> userMngr)
        {
            _context = context;
            userManager = userMngr;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Artists()
        {

            List<User> users = new List<User>();   
            List<ArtistImage> artistImages = new List<ArtistImage>();
           
            foreach (User user in userManager.Users) 
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);

            }
            artistImages = await _context.ArtistImages.ToListAsync();


            ArtistsViewModel model = new ArtistsViewModel
            {
                Users = users,
                /*ArtistImages = artistImages 
*/
            };

            return View(model);
        }

        public IActionResult About_Us()
        {
            return View();
        }

        public IActionResult Exhibitions()
        {
            return View();
        }

        public async Task<IActionResult> Artist(string? id) // View by username
        {
            if (id == null)
            {
                return NotFound();
            }

            ArtistViewModel model = new ArtistViewModel();

            var user = await userManager.FindByNameAsync(id);
            if (user == null) 
            {
                return NotFound();
            }
            model.User = user;

            var arts = from a in _context.Arts.Where(u => u.UserID == user.Id) select a;             
            model.Arts = await arts.ToListAsync();

            var artistImages = from a in _context.ArtistImages.Where(u => u.UserID == user.Id) select a;
            model.ArtistImages = await artistImages.ToListAsync();

            model.ArtImages = await _context.ArtImages.ToListAsync();

            return View(model);
        }

        public IActionResult Art()
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
            var arts = from a in _context.Arts.Include(u => u.User) select a;

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