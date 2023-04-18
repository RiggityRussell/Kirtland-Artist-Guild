using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kirtland_Artist_Guild.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Configuration;

namespace Kirtland_Artist_Guild.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Artist")]
    [Area("Admin")]
    public class ArtController : Controller
    {
        private readonly StoreContext _context;
        private readonly IWebHostEnvironment _env;
        private UserManager<User> userManager;
        private readonly IConfiguration Configuration;

        public ArtController(StoreContext context, UserManager<User> userMngr, IWebHostEnvironment env, IConfiguration configuration)
        {
            _context = context;
            userManager = userMngr;
            _env = env;
            Configuration = configuration;
        }

        // GET: Art
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arts.Where(a => a.UserID == userManager.GetUserId(User)).Include(c => c.ArtColorLinks).ThenInclude(d => d.ArtColor).Include(m => m.ArtMediumLinks).ThenInclude(n => n.ArtMedium).Include(s => s.ArtStyleLinks).ThenInclude(t => t.ArtStyle).ToListAsync());
        }

        // GET: Art/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Arts == null)
            {
                return NotFound();
            }
            var art = await _context.Arts.Include(n => n.ArtMediumLinks).ThenInclude(o => o.ArtMedium).FirstOrDefaultAsync(m => m.ID == id);
            if (art == null)
            {
                return NotFound();
            }
            var images = await _context.ArtImages.Where(i => i.ArtID == id).ToListAsync();
            if (images.Count == 0)
            {
                var defaultImage = Configuration["DefaultImage:Art"];
                images.Add(new ArtImage { ArtID = art.ID, FileName = defaultImage, ID = 0, Source = "/media/" });
            }

            ArtViewModel model = new ArtViewModel
            {
                Art = art,
                ArtImages = images
            };
            var artist = await userManager.FindByIdAsync(art.UserID);
            if (artist != null)
            {
                ViewData["artist"] = artist.UserName;
                ViewData["artistName"] = artist.firstName + " " + artist.lastName;
            }

            return View(model);
        }

        // GET: Art/Create
        public IActionResult Create()
        {
            Art art = new Art() { UserID = userManager.GetUserId(User) };
            return View(art);
        }

        // POST: Art/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,Name,Description,Available,Created,Price")] Art art)
        {
            art.UserID = userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                _context.Add(art);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(art);
        }

        // GET: Art/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Arts == null)
            {
                return NotFound();
            }

            var art = await _context.Arts.Where(a => a.ID == id).Include(c => c.ArtColorLinks).ThenInclude(d => d.ArtColor).Include(n => n.ArtMediumLinks).ThenInclude(o => o.ArtMedium).Include(s => s.ArtStyleLinks).ThenInclude(t => t.ArtStyle).Include(i => i.ArtImages).FirstOrDefaultAsync(m => m.ID == id);
            if (art == null)
            {
                return NotFound();
            }
            return View(art);
        }

        // POST: Art/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,Name,Description,Available,Created,Price")] Art art)
        {
            if (id != art.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(art);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtExists(art.ID))
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
            return View(art);
        }

        // GET: Art/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Arts == null)
            {
                return NotFound();
            }

            var art = await _context.Arts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (art == null)
            {
                return NotFound();
            }

            return View(art);
        }

        // POST: Art/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Arts == null)
            {
                return Problem("Entity set 'StoreContext.Arts'  is null.");
            }
            var art = await _context.Arts.FindAsync(id);
            if (art != null)
            {
                _context.Arts.Remove(art);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ARTCOLORLINK
        public IActionResult ArtColorLinkCreate(int? artid)
        {
            if (artid == null)
            {
                return NotFound();
            }
            ViewData["art"] = artid;
            ViewData["ArtColorID"] = new SelectList(_context.ArtColors, "ID", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArtColorLinkCreate([Bind("ArtID,ArtColorID")] ArtColorLink artColorLink)
        {
            var artcolor = _context.ArtColorLinks.Where(c => c.ArtID == artColorLink.ArtID);
            artcolor = artcolor.Where(c => c.ArtColorID == artColorLink.ArtColorID);
            if (artcolor.ToList().Count != 0)
            {
                return RedirectToAction(nameof(Edit), new { id = artColorLink.ArtID });
            }
            else if (ModelState.IsValid)
            {
                _context.Add(artColorLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), new { id = artColorLink.ArtID });
            }
            ViewData["art"] = artColorLink.ArtID;
            ViewData["ArtColorID"] = new SelectList(_context.ArtColors, "ID", "Name", artColorLink.ArtColorID);
            return View(artColorLink);
        }

        public async Task<IActionResult> ArtColorLinkDelete(int? artid, int? artcolorid)
        {
            if (artid == null || artcolorid == null || _context.Arts == null)
            {
                return NotFound();
            }
            var art = _context.Arts.Include(a => a.ArtColorLinks).Single(a => a.ID == artid);
            if (art.UserID != userManager.GetUserId(User)) { return NotFound(); }
            if (art.ArtColorLinks != null) { art.ArtColorLinks.Remove(art.ArtColorLinks.Where(c => c.ArtColorID == artcolorid).FirstOrDefault()); }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new { id = artid });
        }

        // ARTMEDIUMLINK
        public IActionResult ArtMediumLinkCreate(int? artid)
        {
            if (artid == null)
            {
                return NotFound();
            }
            ViewData["art"] = artid;
            ViewData["ArtMediumID"] = new SelectList(_context.ArtMediums, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArtMediumLinkCreate([Bind("ArtID,ArtMediumID")] ArtMediumLink artMediumLink)
        {
            var artmedium = _context.ArtMediumLinks.Where(c => c.ArtID == artMediumLink.ArtID);
            artmedium = artmedium.Where(c => c.ArtMediumID == artMediumLink.ArtMediumID);
            if (artmedium.ToList().Count != 0)
            {
                return RedirectToAction(nameof(Edit), new { id = artMediumLink.ArtID });
            }
            else if (ModelState.IsValid)
            {
                _context.Add(artMediumLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), new { id = artMediumLink.ArtID });
            }
            ViewData["art"] = artMediumLink.ArtID;
            ViewData["ArtMediumID"] = new SelectList(_context.ArtMediums, "ID", "Name", artMediumLink.ArtMediumID);
            return View(artMediumLink);
        }

        public async Task<IActionResult> ArtMediumLinkDelete(int? artid, int? artmediumid)
        {
            if (artid == null || artmediumid == null || _context.Arts == null)
            {
                return NotFound();
            }
            var art = _context.Arts.Include(a => a.ArtMediumLinks).Single(a => a.ID == artid);
            if (art.UserID != userManager.GetUserId(User)) { return NotFound(); }
            if (art.ArtMediumLinks != null) { art.ArtMediumLinks.Remove(art.ArtMediumLinks.Where(c => c.ArtMediumID == artmediumid).FirstOrDefault()); }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new { id = artid });
        }

        // ARTSTYLELINK
        public IActionResult ArtStyleLinkCreate(int? artid)
        {
            if (artid == null)
            {
                return NotFound();
            }
            ViewData["art"] = artid;
            ViewData["ArtStyleID"] = new SelectList(_context.ArtStyles, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArtStyleLinkCreate([Bind("ArtID,ArtStyleID")] ArtStyleLink artStyleLink)
        {
            var artstyle = _context.ArtStyleLinks.Where(c => c.ArtID == artStyleLink.ArtID);
            artstyle = artstyle.Where(c => c.ArtStyleID == artStyleLink.ArtStyleID);
            if (artstyle.ToList().Count != 0)
            {
                return RedirectToAction(nameof(Edit), new { id = artStyleLink.ArtID });
            }
            else if (ModelState.IsValid)
            {
                _context.Add(artStyleLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), new { id = artStyleLink.ArtID });
            }
            ViewData["art"] = artStyleLink.ArtID;
            ViewData["ArtMediumID"] = new SelectList(_context.ArtStyles, "ID", "Name", artStyleLink.ArtStyleID);
            return View(artStyleLink);
        }
        public async Task<IActionResult> ArtStyleLinkDelete(int? artid, int? artstyleid)
        {
            if (artid == null || artstyleid == null || _context.Arts == null)
            {
                return NotFound();
            }
            var art = _context.Arts.Include(a => a.ArtStyleLinks).Single(a => a.ID == artid);
            if (art.UserID != userManager.GetUserId(User)) { return NotFound(); }
            if (art.ArtStyleLinks != null) { art.ArtStyleLinks.Remove(art.ArtStyleLinks.Where(c => c.ArtStyleID == artstyleid).FirstOrDefault()); }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new { id = artid });
        }

        // ARTIMAGE
        public IActionResult ArtImageCreate(int? artid)
        {
            if (artid == null)
            {
                return NotFound();
            }
            ViewData["art"] = artid;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArtImageCreate(ArtImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ArtImage != null)
                {
                    // Check if the uploaded file has a valid file extension
                    string fileExtension = Path.GetExtension(model.ArtImage.FileName).ToLower();
                    if (fileExtension != ".png" && fileExtension != ".jpg" && fileExtension != ".jpeg")
                    {
                        ModelState.AddModelError("ArtImage", "Invalid file format. Only .png, .jpg, and .jpeg files are allowed.");
                        ViewData["art"] = model.ArtID;
                        return View(model);
                    }

                    // Process the uploaded image and save it to the server
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
                    return RedirectToAction(nameof(Edit), new { id = model.ArtID });
                }
                else
                {
                    ModelState.AddModelError("ArtImage", "Please select a file to upload.");
                    return View(model);
                }
            }

            ViewData["art"] = model.ArtID;
            return View(model);
        }

        public async Task<IActionResult> ArtImageDelete(int? artid, int? artimageid)
        {
            if (artimageid == null || artid == null || _context.ArtImages == null)
            {
                return NotFound();
            }
            var artImage = await _context.ArtImages.FindAsync(artimageid);
            var art = _context.Arts.Single(a => a.ID == artid);
            if (art.UserID != userManager.GetUserId(User)) { return NotFound(); }
            if (artImage != null)
            {
                _context.ArtImages.Remove(artImage);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new { id = artid });
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

        private bool ArtExists(int id)
        {
            return _context.Arts.Any(e => e.ID == id);
        }
    }
}