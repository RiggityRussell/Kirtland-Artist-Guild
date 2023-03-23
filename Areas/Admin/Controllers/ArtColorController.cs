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
    public class ArtColorController : Controller
    {
        private readonly StoreContext _context;

        public ArtColorController(StoreContext context)
        {
            _context = context;
        }

        // GET: ArtColor
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArtColors.ToListAsync());
        }

        // GET: ArtColor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtColors == null)
            {
                return NotFound();
            }

            var artColor = await _context.ArtColors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artColor == null)
            {
                return NotFound();
            }

            return View(artColor);
        }

        // GET: ArtColor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtColor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ArtColor artColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artColor);
        }

        // GET: ArtColor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtColors == null)
            {
                return NotFound();
            }

            var artColor = await _context.ArtColors.FindAsync(id);
            if (artColor == null)
            {
                return NotFound();
            }
            return View(artColor);
        }

        // POST: ArtColor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] ArtColor artColor)
        {
            if (id != artColor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtColorExists(artColor.ID))
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
            return View(artColor);
        }

        // GET: ArtColor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtColors == null)
            {
                return NotFound();
            }

            var artColor = await _context.ArtColors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artColor == null)
            {
                return NotFound();
            }

            return View(artColor);
        }

        // POST: ArtColor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtColors == null)
            {
                return Problem("Entity set 'StoreContext.ArtColors'  is null.");
            }
            var artColor = await _context.ArtColors.FindAsync(id);
            if (artColor != null)
            {
                _context.ArtColors.Remove(artColor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtColorExists(int id)
        {
            return _context.ArtColors.Any(e => e.ID == id);
        }
    }
}
