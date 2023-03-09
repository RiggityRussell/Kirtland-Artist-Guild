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
    public class ArtMediumLinkController : Controller
    {
        private readonly StoreContext _context;

        public ArtMediumLinkController(StoreContext context)
        {
            _context = context;
        }

        // GET: ArtMediumLink
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.ArtMediumLinks.Include(a => a.Art).Include(a => a.ArtMedium);
            return View(await storeContext.ToListAsync());
        }

        // GET: ArtMediumLink/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtMediumLinks == null)
            {
                return NotFound();
            }

            var artMediumLink = await _context.ArtMediumLinks
                .Include(a => a.Art)
                .Include(a => a.ArtMedium)
                .FirstOrDefaultAsync(m => m.ArtID == id);
            if (artMediumLink == null)
            {
                return NotFound();
            }

            return View(artMediumLink);
        }

        // GET: ArtMediumLink/Create
        public IActionResult Create()
        {
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Description");
            ViewData["ArtMediumID"] = new SelectList(_context.ArtMediums, "ID", "Name");
            return View();
        }

        // POST: ArtMediumLink/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtID,ArtMediumID")] ArtMediumLink artMediumLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artMediumLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Description", artMediumLink.ArtID);
            ViewData["ArtMediumID"] = new SelectList(_context.ArtMediums, "ID", "Name", artMediumLink.ArtMediumID);
            return View(artMediumLink);
        }

        // GET: ArtMediumLink/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtMediumLinks == null)
            {
                return NotFound();
            }

            var artMediumLink = await _context.ArtMediumLinks.FindAsync(id);
            if (artMediumLink == null)
            {
                return NotFound();
            }
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Description", artMediumLink.ArtID);
            ViewData["ArtMediumID"] = new SelectList(_context.ArtMediums, "ID", "Name", artMediumLink.ArtMediumID);
            return View(artMediumLink);
        }

        // POST: ArtMediumLink/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtID,ArtMediumID")] ArtMediumLink artMediumLink)
        {
            if (id != artMediumLink.ArtID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artMediumLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtMediumLinkExists(artMediumLink.ArtID))
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
            ViewData["ArtID"] = new SelectList(_context.Arts, "ID", "Description", artMediumLink.ArtID);
            ViewData["ArtMediumID"] = new SelectList(_context.ArtMediums, "ID", "Name", artMediumLink.ArtMediumID);
            return View(artMediumLink);
        }

        // GET: ArtMediumLink/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtMediumLinks == null)
            {
                return NotFound();
            }

            var artMediumLink = await _context.ArtMediumLinks
                .Include(a => a.Art)
                .Include(a => a.ArtMedium)
                .FirstOrDefaultAsync(m => m.ArtID == id);
            if (artMediumLink == null)
            {
                return NotFound();
            }

            return View(artMediumLink);
        }

        // POST: ArtMediumLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtMediumLinks == null)
            {
                return Problem("Entity set 'StoreContext.ArtMediumLinks'  is null.");
            }
            var artMediumLink = await _context.ArtMediumLinks.FindAsync(id);
            if (artMediumLink != null)
            {
                _context.ArtMediumLinks.Remove(artMediumLink);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtMediumLinkExists(int id)
        {
          return _context.ArtMediumLinks.Any(e => e.ArtID == id);
        }
    }
}
