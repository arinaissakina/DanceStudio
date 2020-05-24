using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanceStudio.Data;
using DanceStudio.Models;
using Microsoft.AspNetCore.Authorization;

namespace DanceStudio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GroupController : Controller
    {
        private readonly DanceStudioContext _context;

        public GroupController(DanceStudioContext context)
        {
            _context = context;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            var danceStudioContext = _context.Groups.Include(a => a.Coach)
                .Include(b => b.Dance);
            return View(await danceStudioContext.ToListAsync());
        }

        // GET: Group/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .Include(a => a.Coach)
                .Include(b => b.Dance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Group/Create
        public IActionResult Create()
        {
            ViewData["CoachId"] = new SelectList(_context.Coaches, "Id", "Name");
            ViewData["DanceId"] = new SelectList(_context.Dances, "Id", "Name");
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CoachId,DanceId")] Group @group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoachId"] = new SelectList(_context.Coaches, "Id", "Name", @group.CoachId);
            ViewData["DanceId"] = new SelectList(_context.Dances, "Id", "Name", @group.DanceId);
            return View(@group);
        }

        // GET: Group/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            ViewData["CoachId"] = new SelectList(_context.Coaches, "Id", "Name", @group.CoachId);
            ViewData["DanceId"] = new SelectList(_context.Dances, "Id", "Name", @group.DanceId);
            return View(@group);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,CoachId,DanceId")] Group @group)
        {
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.Id))
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
            ViewData["CoachId"] = new SelectList(_context.Coaches, "Id", "Name", @group.CoachId);
            ViewData["DanceId"] = new SelectList(_context.Dances, "Id", "Name", @group.DanceId);
            return View(@group);
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .Include(a => a.Coach)
                .Include(b => b.Dance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var @group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(long id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
