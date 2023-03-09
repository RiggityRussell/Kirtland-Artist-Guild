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
    public class ArtMediumController : Controller
    {
        private readonly StoreContext _context;

        public ArtMediumController(StoreContext context)
        {
            _context = context;
        }

        // GET: ArtMedium
        public async Task<IActionResult> Index()
        {
              return View(await _context.ArtMediums.ToListAsync());
        }

        // GET: ArtMedium/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtMediums == null)
            {
                return NotFound();
            }

            var artMedium = await _context.ArtMediums
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artMedium == null)
            {
                return NotFound();
            }

            return View(artMedium);
        }

        // GET: ArtMedium/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtMedium/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ArtMedium artMedium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artMedium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artMedium);
        }

        // GET: ArtMedium/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtMediums == null)
            {
                return NotFound();
            }

            var artMedium = await _context.ArtMediums.FindAsync(id);
            if (artMedium == null)
            {
                return NotFound();
            }
            return View(artMedium);
        }

        // POST: ArtMedium/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] ArtMedium artMedium)
        {
            if (id != artMedium.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artMedium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtMediumExists(artMedium.ID))
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
            return View(artMedium);
        }

        // GET: ArtMedium/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtMediums == null)
            {
                return NotFound();
            }

            var artMedium = await _context.ArtMediums
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artMedium == null)
            {
                return NotFound();
            }

            return View(artMedium);
        }

        // POST: ArtMedium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtMediums == null)
            {
                return Problem("Entity set 'StoreContext.ArtMediums'  is null.");
            }
            var artMedium = await _context.ArtMediums.FindAsync(id);
            if (artMedium != null)
            {
                _context.ArtMediums.Remove(artMedium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtMediumExists(int id)
        {
          return _context.ArtMediums.Any(e => e.ID == id);
        }
    }
}
