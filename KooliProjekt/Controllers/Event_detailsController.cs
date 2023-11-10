using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Controllers
{
    public class Event_detailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Event_detailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Event_details
        public async Task<IActionResult> Index(int page = 1)
        {
              return View(await _context.Event_Details.GetPagedAsync(page, 2));
        }

        // GET: Event_details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Event_Details == null)
            {
                return NotFound();
            }

            var event_details = await _context.Event_Details
                .FirstOrDefaultAsync(m => m.Id == id);
            if (event_details == null)
            {
                return NotFound();
            }

            return View(event_details);
        }

        // GET: Event_details/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,is_payed")] Event_details event_details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(event_details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(event_details);
        }

        // GET: Event_details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Event_Details == null)
            {
                return NotFound();
            }

            var event_details = await _context.Event_Details.FindAsync(id);
            if (event_details == null)
            {
                return NotFound();
            }
            return View(event_details);
        }

        // POST: Event_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,is_payed")] Event_details event_details)
        {
            if (id != event_details.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(event_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Event_detailsExists(event_details.Id))
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
            return View(event_details);
        }

        // GET: Event_details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Event_Details == null)
            {
                return NotFound();
            }

            var event_details = await _context.Event_Details
                .FirstOrDefaultAsync(m => m.Id == id);
            if (event_details == null)
            {
                return NotFound();
            }

            return View(event_details);
        }

        // POST: Event_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Event_Details == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Event_Details'  is null.");
            }
            var event_details = await _context.Event_Details.FindAsync(id);
            if (event_details != null)
            {
                _context.Event_Details.Remove(event_details);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Event_detailsExists(int id)
        {
          return _context.Event_Details.Any(e => e.Id == id);
        }
    }
}
