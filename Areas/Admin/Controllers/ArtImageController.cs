﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kirtland_Artist_Guild.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Kirtland_Artist_Guild.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Artist")]
    [Area("Admin")]
    public class ArtImageController : Controller
    {
        private readonly StoreContext _context;
        private readonly IWebHostEnvironment _env;
        private UserManager<User> userManager;

        public ArtImageController(StoreContext context, IWebHostEnvironment env, UserManager<User> userMngr)
        {
            _context = context;
            _env = env;
            userManager = userMngr;
        }

        // GET: ArtImage
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.ArtImages.Include(a => a.Art);
            return View(await storeContext.ToListAsync());
        }

        // GET: ArtImage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtImages == null)
            {
                return NotFound();
            }

            var artImage = await _context.ArtImages
                .Include(a => a.Art)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artImage == null)
            {
                return NotFound();
            }

            return View(artImage);
        }

        // GET: ArtImage/Create
        public IActionResult Create()
        {
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name");
            return View();
        }

        // POST: ArtImage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtImageViewModel model)
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

                ArtImage artImage = new ArtImage
                {
                    Source = uploadFolder,
                    FileName = fileName,
                    ArtID = model.ArtID                    
                };

                _context.Add(artImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name", model.ArtID);
            return View();
        }

        private string UploadedFile(ArtImageViewModel model)
        {
            string? uploadFileName = null;

            if (model.ArtImage != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "media/uploads/" + userManager.GetUserId(User));
                uploadFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ArtImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uploadFileName);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ArtImage.CopyTo(fileStream);
                }
            }
            return uploadFileName;
        }

        // GET: ArtImage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtImages == null)
            {
                return NotFound();
            }

            var artImage = await _context.ArtImages.FindAsync(id);
            if (artImage == null)
            {
                return NotFound();
            }
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name", artImage.ArtID);
            return View(artImage);
        }

        // POST: ArtImage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ArtID,FileName,Source")] ArtImage artImage)
        {
            if (id != artImage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtImageExists(artImage.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name", artImage.ArtID);
            return View(artImage);
        }

        // GET: ArtImage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtImages == null)
            {
                return NotFound();
            }

            var artImage = await _context.ArtImages
                .Include(a => a.Art)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artImage == null)
            {
                return NotFound();
            }

            return View(artImage);
        }

        // POST: ArtImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtImages == null)
            {
                return Problem("Entity set 'StoreContext.ArtImages'  is null.");
            }
            var artImage = await _context.ArtImages.FindAsync(id);
            if (artImage != null)
            {
                _context.ArtImages.Remove(artImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtImageExists(int id)
        {
            return _context.ArtImages.Any(e => e.ID == id);
        }
    }
}
