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
using Microsoft.AspNetCore.Authorization;

namespace KooliProjekt.Controllers
{
    [Authorize]
    public class Event_detailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEvent_detailsService _Event_detailsService;
        private readonly IEventService _eventService;
        private readonly IReceiptService _receiptService;



        public Event_detailsController(ApplicationDbContext context, IEvent_detailsService Event_detailsService, IEventService eventService, IReceiptService receiptService)
        {
            _context = context;
            _Event_detailsService = Event_detailsService;
            _eventService = eventService;
            _receiptService = receiptService;
        }

        public async Task<IActionResult> Register(int? id)
        {
            Event_details newRegistratedUser = new Event_details();
            newRegistratedUser.user = _context.Users.FirstOrDefault(o => o.Email == User.Identity.Name);
            newRegistratedUser.user_Id = newRegistratedUser.user.Id;
            newRegistratedUser.event_Id = id.Value;
            newRegistratedUser.is_payed = false;
            await _Event_detailsService.Save(newRegistratedUser);
            return RedirectToAction(nameof(MyEvent_details));
        }

        public async Task<IActionResult> Pay(int? id)
        {
            var @event = await _Event_detailsService.GetById(id.Value);
            @event.is_payed = true;

            return RedirectToAction(nameof(MyEvent_details));
        }

        // GET: Event_details
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _Event_detailsService.List(page, 10));
        }

        public async Task<IActionResult> MyEvent_details()
        {


            string loggedInUsername = User.Identity.Name; // Get the logged-in username


            List<Event_details> event_Details = await _Event_detailsService.GetEvent_details(loggedInUsername);

            return View(event_Details);
        }

        // GET: Event_details/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Event_Details == null)
            {
                return NotFound();
            }

            var event_details = await _Event_detailsService.GetById(id.Value);
            if (event_details == null)
            {
                return NotFound();
            }

            return View(event_details);
        }

        // GET: Event_details/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["event_Id"] = new SelectList(_context.Events, "Id", "event_name");
            ViewData["user_Id"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Event_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,user_Id,event_Id,is_payed")] Event_details event_details)
        {
            if (ModelState.IsValid)
            {
                await _Event_detailsService.Save(event_details);
                return RedirectToAction(nameof(Index));
            }
            ViewData["event_Id"] = new SelectList(_context.Events, "Id", "event_name", event_details.event_Id);
            ViewData["user_Id"] = new SelectList(_context.Users, "Id", "UserName", event_details.user_Id);
            return View(event_details);
        }

        // GET: Event_details/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Event_Details == null)
            {
                return NotFound();
            }

            var event_details = await _Event_detailsService.GetById(id.Value);
            if (event_details == null)
            {
                return NotFound();
            }
            ViewData["event_Id"] = new SelectList(_context.Events, "Id", "Id", event_details.event_Id);
            ViewData["user_Id"] = new SelectList(_context.Users, "Id", "Id", event_details.user_Id);
            return View(event_details);
        }

        // POST: Event_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,user_Id,event_Id,is_payed")] Event_details event_details)
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
                    await _Event_detailsService.Save(event_details);
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
            ViewData["event_Id"] = new SelectList(_context.Events, "Id", "Id", event_details.event_Id);
            ViewData["user_Id"] = new SelectList(_context.Users, "Id", "Id", event_details.user_Id);
            return View(event_details);
        }

        // GET: Event_details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Event_Details == null)
            {
                return NotFound();
            }

            var event_details = await _Event_detailsService.GetById(id.Value);
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
            await _Event_detailsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool Event_detailsExists(int id)
        {
            return _context.Event_Details.Any(e => e.Id == id);
        }
    }
}
