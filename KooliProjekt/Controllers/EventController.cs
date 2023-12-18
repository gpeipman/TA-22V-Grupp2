using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;
using Microsoft.AspNetCore.Identity;
using KooliProjekt.Services;

namespace KooliProjekt.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ApplicationDbContext _context;


        public EventController(ApplicationDbContext context,IEventService eventService)
        {
            _context = context;
            _eventService = eventService;
        }

        // GET: Event
        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _eventService.List(page, 2));
        }
        public IActionResult AllEvents()
        {
            List<Event> events = _context.Events.ToList();
            return View(events);
        }
        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _eventService.GetById(id.Value);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            ViewData["user_Id"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,event_name,event_date_start,event_date_end,event_description,user_Id,MaxParticipants,event_price")] Event @event)
        {

            if (ModelState.IsValid)
            {
                await _eventService.Save(@event);
                return RedirectToAction(nameof(Index));
            }
            ViewData["user_Id"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", @event.user_Id);
            return View(@event);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _eventService.GetById(id.Value);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["user_Id"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", @event.user_Id);
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,event_name,event_date_start,event_date_end,event_description,user_Id,MaxParticipants,event_price")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            await _eventService.Save(@event);
            ViewData["user_Id"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", @event.user_Id);
            return View(@event);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _eventService.GetById(id.Value);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
