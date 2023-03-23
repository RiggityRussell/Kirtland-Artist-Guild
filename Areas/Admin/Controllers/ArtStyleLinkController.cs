using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kirtland_Artist_Guild.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kirtland_Artist_Guild.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ArtStyleLinkController : Controller
    {
        private readonly StoreContext _context;

        public ArtStyleLinkController(StoreContext context)
        {
            _context = context;
        }

        // GET: ArtStyleLink
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.ArtStyleLinks.Include(a => a.Art).Include(a => a.ArtStyle);
            return View(await storeContext.ToListAsync());
        }

        // GET: ArtStyleLink/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtStyleLinks == null)
            {
                return NotFound();
            }

            var artStyleLink = await _context.ArtStyleLinks
                .Include(a => a.Art)
                .Include(a => a.ArtStyle)
                .FirstOrDefaultAsync(m => m.ArtID == id);
            if (artStyleLink == null)
            {
                return NotFound();
            }

            return View(artStyleLink);
        }

        // GET: ArtStyleLink/Create
        public IActionResult Create()
        {
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name");
            ViewData["ArtStyleID"] = new SelectList(_context.ArtStyles, "ID", "Name");
            return View();
        }

        // POST: ArtStyleLink/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtID,ArtStyleID")] ArtStyleLink artStyleLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artStyleLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name", artStyleLink.ArtID);
            ViewData["ArtStyleID"] = new SelectList(_context.ArtStyles, "ID", "Name", artStyleLink.ArtStyleID);
            return View(artStyleLink);
        }

        // GET: ArtStyleLink/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtStyleLinks == null)
            {
                return NotFound();
            }

            var artStyleLink = await _context.ArtStyleLinks.FindAsync(id);
            if (artStyleLink == null)
            {
                return NotFound();
            }
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name", artStyleLink.ArtID);
            ViewData["ArtStyleID"] = new SelectList(_context.ArtStyles, "ID", "Name", artStyleLink.ArtStyleID);
            return View(artStyleLink);
        }

        // POST: ArtStyleLink/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtID,ArtStyleID")] ArtStyleLink artStyleLink)
        {
            if (id != artStyleLink.ArtID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artStyleLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtStyleLinkExists(artStyleLink.ArtID))
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
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name", artStyleLink.ArtID);
            ViewData["ArtStyleID"] = new SelectList(_context.ArtStyles, "ID", "Name", artStyleLink.ArtStyleID);
            return View(artStyleLink);
        }

        // GET: ArtStyleLink/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtStyleLinks == null)
            {
                return NotFound();
            }

            var artStyleLink = await _context.ArtStyleLinks
                .Include(a => a.Art)
                .Include(a => a.ArtStyle)
                .FirstOrDefaultAsync(m => m.ArtID == id);
            if (artStyleLink == null)
            {
                return NotFound();
            }

            return View(artStyleLink);
        }

        // POST: ArtStyleLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtStyleLinks == null)
            {
                return Problem("Entity set 'StoreContext.ArtStyleLinks'  is null.");
            }
            var artStyleLink = await _context.ArtStyleLinks.FindAsync(id);
            if (artStyleLink != null)
            {
                _context.ArtStyleLinks.Remove(artStyleLink);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtStyleLinkExists(int id)
        {
            return _context.ArtStyleLinks.Any(e => e.ArtID == id);
        }
    }
}
