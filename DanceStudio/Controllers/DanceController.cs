using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanceStudio.Data;
using DanceStudio.Models;

namespace DanceStudio.Controllers
{
    public class DanceController : Controller
    {
        private readonly DanceStudioContext _context;

        public DanceController(DanceStudioContext context)
        {
            _context = context;
        }

        // GET: Dance
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dances.ToListAsync());
        }

        // GET: Dance/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dance = await _context.Dances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dance == null)
            {
                return NotFound();
            }

            return View(dance);
        }

        // GET: Dance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Dance dance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dance);
        }

        // GET: Dance/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dance = await _context.Dances.FindAsync(id);
            if (dance == null)
            {
                return NotFound();
            }
            return View(dance);
        }

        // POST: Dance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] Dance dance)
        {
            if (id != dance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanceExists(dance.Id))
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
            return View(dance);
        }

        // GET: Dance/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dance = await _context.Dances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dance == null)
            {
                return NotFound();
            }

            return View(dance);
        }

        // POST: Dance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dance = await _context.Dances.FindAsync(id);
            _context.Dances.Remove(dance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanceExists(long id)
        {
            return _context.Dances.Any(e => e.Id == id);
        }
    }
}
