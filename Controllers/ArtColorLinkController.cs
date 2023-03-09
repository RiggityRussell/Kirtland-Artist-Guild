using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kirtland_Artist_Guild.Models;

namespace Kirtland_Artist_Guild.Controllers
{
    public class ArtColorLinkController : Controller
    {
        private readonly StoreContext _context;

        public ArtColorLinkController(StoreContext context)
        {
            _context = context;
        }

        // GET: ArtColorLink
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.ArtColorLinks.Include(a => a.Art).Include(a => a.ArtColor);
            return View(await storeContext.ToListAsync());
        }

        // GET: ArtColorLink/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtColorLinks == null)
            {
                return NotFound();
            }

            var artColorLink = await _context.ArtColorLinks
                .Include(a => a.Art)
                .Include(a => a.ArtColor)
                .FirstOrDefaultAsync(m => m.ArtID == id);
            if (artColorLink == null)
            {
                return NotFound();
            }

            return View(artColorLink);
        }

        // GET: ArtColorLink/Create
        public IActionResult Create()
        {
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name");
            ViewData["ArtColorID"] = new SelectList(_context.ArtColors, "ID", "Name");
            return View();
        }

        // POST: ArtColorLink/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtID,ArtColorID")] ArtColorLink artColorLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artColorLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name", artColorLink.ArtID);
            ViewData["ArtColorID"] = new SelectList(_context.ArtColors, "ID", "Name", artColorLink.ArtColorID);
            return View(artColorLink);
        }

        // GET: ArtColorLink/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtColorLinks == null)
            {
                return NotFound();
            }

            var artColorLink = await _context.ArtColorLinks.FindAsync(id);
            if (artColorLink == null)
            {
                return NotFound();
            }
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name", artColorLink.ArtID);
            ViewData["ArtColorID"] = new SelectList(_context.ArtColors, "ID", "Name", artColorLink.ArtColorID);
            return View(artColorLink);
        }

        // POST: ArtColorLink/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtID,ArtColorID")] ArtColorLink artColorLink)
        {
            if (id != artColorLink.ArtID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artColorLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtColorLinkExists(artColorLink.ArtID))
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
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Name", artColorLink.ArtID);
            ViewData["ArtColorID"] = new SelectList(_context.ArtColors, "ID", "Name", artColorLink.ArtColorID);
            return View(artColorLink);
        }

        // GET: ArtColorLink/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtColorLinks == null)
            {
                return NotFound();
            }

            var artColorLink = await _context.ArtColorLinks
                .Include(a => a.Art)
                .Include(a => a.ArtColor)
                .FirstOrDefaultAsync(m => m.ArtID == id);
            if (artColorLink == null)
            {
                return NotFound();
            }

            return View(artColorLink);
        }

        // POST: ArtColorLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtColorLinks == null)
            {
                return Problem("Entity set 'StoreContext.ArtColorLinks'  is null.");
            }
            var artColorLink = await _context.ArtColorLinks.FindAsync(id);
            if (artColorLink != null)
            {
                _context.ArtColorLinks.Remove(artColorLink);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtColorLinkExists(int id)
        {
          return _context.ArtColorLinks.Any(e => e.ArtID == id);
        }
    }
}
