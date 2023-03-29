using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Kirtland_Artist_Guild.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Kirtland_Artist_Guild.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Artist")]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userMngr, SignInManager<User> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
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

        public IActionResult ProfileImageIndex()
        {
            return View();
        }
    }
}
