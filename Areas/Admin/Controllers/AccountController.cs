using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Kirtland_Artist_Guild.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Kirtland_Artist_Guild.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Artist")]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly StoreContext _context;

        public AccountController(UserManager<User> userMngr, SignInManager<User> signInMngr, IWebHostEnvironment env, StoreContext context)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            _env = env;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel
            {
                Username = User.Identity?.Name ?? ""
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(model.Username);
                var result = await userManager.ChangePasswordAsync(user,
                    model.OldPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    TempData["message"] = "Password changed successfully";
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeProfile()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("Unable to load user");
            }
            var model = new ChangeProfileViewModel
            {
                Username = User.Identity?.Name ?? "",
                firstName = user.firstName ?? "",
                lastName = user.lastName ?? "",
                artistMedium = user.artistMedium ?? "",
                quote = user.quote ?? "",
                bio = user.bio ?? ""
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProfile(ChangeProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(model.Username);

                user.firstName = model.firstName;
                user.lastName = model.lastName;
                user.artistMedium = model.artistMedium;
                user.quote = model.quote;
                user.bio = model.bio;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    TempData["message"] = "Profile changed successfully";
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }


        // GET: ArtistImage
        public async Task<IActionResult> ProfileImageIndex()
        {
            var storeContext = _context.ArtistImages.Include(a => a.User);
            return View(await storeContext.ToListAsync());
        }

      

        // GET: ArtistImage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtistImage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtistImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uploadFileName = UploadedFile(model);
                if (uploadFileName == null)
                {
                    return NotFound();
                }

                string uploadFolder = "/media/uploads/" + userManager.GetUserId(User) + "/";
                string fileName = Path.GetFileName(uploadFileName);

                ArtistImage artistImage = new ArtistImage
                {
                    Source = uploadFolder,
                    FileName = fileName,
                    UserID = userManager.GetUserId(User)
                };

                _context.Add(artistImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProfileImageIndex));
            }
            return View();
        }


        // GET: ArtistImage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtistImages == null)
            {
                return NotFound();
            }

            var artistImage = await _context.ArtistImages
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artistImage == null)
            {
                return NotFound();
            }

            return View(artistImage);
        }

        // POST: ArtistImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtistImages == null)
            {
                return Problem("Entity set 'StoreContext.ArtistImages'  is null.");
            }
            var artistImage = await _context.ArtistImages.FindAsync(id);
            if (artistImage != null)
            {
                _context.ArtistImages.Remove(artistImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ProfileImageIndex));
        }

        private bool ArtistImageExists(int id)
        {
            return (_context.ArtistImages?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        private string UploadedFile(ArtistImageViewModel model)
        {
            string? uploadFileName = null;

            if (model.ArtistImage != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "media/uploads/" + userManager.GetUserId(User));
                uploadFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ArtistImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uploadFileName);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ArtistImage.CopyTo(fileStream);
                }
            }
            return uploadFileName;
        }
    }
}
