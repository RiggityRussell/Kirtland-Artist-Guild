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
    public class ArtStyleController : Controller
    {
        private readonly StoreContext _context;

        public ArtStyleController(StoreContext context)
        {
            _context = context;
        }

        // GET: ArtStyle
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArtStyles.OrderBy(c => c.Name).ToListAsync());
        }

        // GET: ArtStyle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtStyle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ArtStyle artStyle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artStyle);
        }

        // GET: ArtStyle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtStyles == null)
            {
                return NotFound();
            }

            var artStyle = await _context.ArtStyles.FindAsync(id);
            if (artStyle == null)
            {
                return NotFound();
            }
            return View(artStyle);
        }

        // POST: ArtStyle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] ArtStyle artStyle)
        {
            if (id != artStyle.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtStyleExists(artStyle.ID))
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
            return View(artStyle);
        }

        // GET: ArtStyle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtStyles == null)
            {
                return NotFound();
            }

            var artStyle = await _context.ArtStyles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artStyle == null)
            {
                return NotFound();
            }

            return View(artStyle);
        }

        // POST: ArtStyle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtStyles == null)
            {
                return Problem("Entity set 'StoreContext.ArtStyles'  is null.");
            }
            var artStyle = await _context.ArtStyles.FindAsync(id);
            if (artStyle != null)
            {
                _context.ArtStyles.Remove(artStyle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtStyleExists(int id)
        {
            return _context.ArtStyles.Any(e => e.ID == id);
        }
    }
}