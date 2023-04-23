using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kirtland_Artist_Guild.Models;
using Microsoft.AspNetCore.Identity;

namespace Kirtland_Artist_Guild.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExhibitionController : Controller
    {
        private readonly StoreContext _context;
        private readonly IWebHostEnvironment _env;

        public ExhibitionController(StoreContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Exhibition
        public async Task<IActionResult> Index()
        {
            if (_context.Exhibitions == null)
            {
                return Problem("Entity set 'StoreContext.Exhibitions' is null.");
            }
            var exhibitions = await _context.Exhibitions.ToListAsync();
            exhibitions.Sort((x, y) => x.StartDate.CompareTo(y.StartDate)); // Sort by StartDate

            return View(exhibitions);
        }

        // GET: Admin/Exhibition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Exhibitions == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibitions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exhibition == null)
            {
                return NotFound();
            }

            return View(exhibition);
        }

        // GET: Admin/Exhibition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Exhibition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,StartDate,FileName,Source")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exhibition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exhibition);
        }

        // GET: Admin/Exhibition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Exhibitions == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibitions.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }
            return View(exhibition);
        }

        // POST: Admin/Exhibition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,StartDate,FileName,Source")] Exhibition exhibition)
        {
            if (id != exhibition.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhibition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitionExists(exhibition.ID))
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
            return View(exhibition);
        }

        // GET: Admin/Exhibition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exhibitions == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibitions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exhibition == null)
            {
                return NotFound();
            }

            return View(exhibition);
        }

        // POST: Admin/Exhibition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exhibitions == null)
            {
                return Problem("Entity set 'StoreContext.Exhibitions'  is null.");
            }
            var exhibition = await _context.Exhibitions.FindAsync(id);
            if (exhibition != null)
            {
                _context.Exhibitions.Remove(exhibition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ExhibitionImageCreate(int? id)
        {
            if (id == null || _context.Exhibitions == null)
            {
                return NotFound();
            }
            var exhibition = await _context.Exhibitions.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }
            ExhibitionImageViewModel model = new ExhibitionImageViewModel
            {
                exhibition = exhibition
            };
            ViewData["exhibition"] = id;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExhibitionImageCreate(ExhibitionImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ExhibitionImage != null)
                {
                    // Check if the uploaded file has a valid file extension
                    string fileExtension = Path.GetExtension(model.ExhibitionImage.FileName).ToLower();
                    if (fileExtension != ".png" && fileExtension != ".jpg" && fileExtension != ".jpeg")
                    {
                        ModelState.AddModelError("ExhibitionImage", "Invalid file format. Only .png, .jpg, and .jpeg files are allowed.");
                        ViewData["exhibition"] = model.exhibition.ID;
                        return View(model);
                    }

                    // Process the uploaded image and save it to the server
                    string uploadFileName = UploadedFile(model);
                    if (uploadFileName == null)
                    {
                        return NotFound();
                    }
                    string uploadFolder = "/media/uploads/exhibitions/";
                    string fileName = Path.GetFileName(uploadFileName);

                    model.exhibition.Source = uploadFolder;
                    model.exhibition.FileName = fileName;

                    try
                    {
                        _context.Update(model.exhibition);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ExhibitionExists(model.exhibition.ID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Edit), new { id = model.exhibition.ID });
                }
                else
                {
                    ModelState.AddModelError("ExhibitionImage", "Please select a file to upload.");
                    return View(model);
                }
            }

            ViewData["exhibition"] = model.exhibition.ID;
            return View(model);
        }

        public async Task<IActionResult> ExhibitionImageDelete(int? id)
        {
            if (id == null || _context.Exhibitions == null)
            {
                return NotFound();
            }
            var exhibition = await _context.Exhibitions.FindAsync(id);
            if (exhibition != null)
            {
                exhibition.Source = null;
                exhibition.FileName = null;
                try
                {
                    _context.Update(exhibition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitionExists(exhibition.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Edit), new { id = id });
        }

        private string UploadedFile(ExhibitionImageViewModel model)
        {
            string? uploadFileName = null;

            if (model != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "media/uploads/exhibitions/");
                uploadFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ExhibitionImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uploadFileName);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ExhibitionImage.CopyTo(fileStream);
                }
            }
            return uploadFileName;
        }

        private bool ExhibitionExists(int id)
        {
          return (_context.Exhibitions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
