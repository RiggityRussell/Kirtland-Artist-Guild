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
    [Authorize(Roles = "Admin,Artist")]
    [Area("Admin")]
    public class ArtController : Controller
    {
        private readonly StoreContext _context;

        public ArtController(StoreContext context)
        {
            _context = context;
        }

        // GET: Art
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arts.ToListAsync());
        }

        // GET: Art/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Art/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Art/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,Name,Description,Available,Created,Price,Shipping")] Art art)
        {
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

            var art = await _context.Arts.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,Name,Description,Available,Created,Price,Shipping")] Art art)
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

        private bool ArtExists(int id)
        {
            return _context.Arts.Any(e => e.ID == id);
        }
    }
}
