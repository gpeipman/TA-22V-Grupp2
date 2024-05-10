using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Authorization;

namespace KooliProjekt.Controllers
{
    [Authorize]
    public class ReceiptController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IEvent_detailsService _event_DetailsService;

        private readonly IReceiptService _receiptService;
        private readonly ApplicationDbContext _context;


        public ReceiptController(ApplicationDbContext context, IReceiptService receiptService, IEventService eventService, IEvent_detailsService event_DetailsService)
        {
            _context = context;
            _receiptService = receiptService;
            _eventService = eventService;
            _event_DetailsService = event_DetailsService;
        }

        // GET: Receipt
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _receiptService.List(page, 2));
        }

        // GET: Receipt/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Receipts == null)
            {
                return NotFound();
            }


            var receipts = await _receiptService.GetById(id.Value);
            if (receipts == null)
            {
                return NotFound();
            }

            return View(receipts);
        }

        /*public async Task<IActionResult> Pay(int? id, string? user)
        {
            string loggedInUsername = User.Identity.Name; // Get the logged-in username

            await _receiptService.Pay(id);

            Receipts receipt = new Receipts();

            receipt.event_Id = @event.event_Id;
            receipt.user_Id = @event.user_Id;

            await _receiptService.Save(receipt);

            return RedirectToAction(nameof(MyReceipts));

        }*/

        public IActionResult MyReceipts()
        {
            string loggedInUsername = User.Identity.Name; // Get the logged-in username


            List<Receipts> receipts = _context.Receipts
                .Where(o => o.user.Email == loggedInUsername)
                .Include(o => o.@event)
                .Include(o => o.user)
                .ToList();

            return View(receipts);
        }

        // GET: Receipt/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["event_Id"] = new SelectList(_context.Events, "Id", "Id");
            ViewData["user_Id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Receipt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,user_Id,event_Id")] Receipts receipts)
        {
            if (ModelState.IsValid)
            {
                await _receiptService.Save(receipts);
                return RedirectToAction(nameof(Index));
            }
            ViewData["event_Id"] = new SelectList(_context.Events, "Id", "Id", receipts.event_Id);
            ViewData["user_Id"] = new SelectList(_context.Users, "Id", "Id", receipts.user_Id);
            return View(receipts);
        }

        public async Task<IActionResult> Receipt(int? id)
        {
            var Receipt = await _receiptService.GetById(id.Value);
            var Event = await _eventService.GetById(Receipt.event_Id);
            var Event_duration = Event.event_date_end - Event.event_date_start;

            return View(Event);
        }

        // GET: Receipt/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Receipts == null)
            {
                return NotFound();
            }

            var receipts = await _receiptService.GetById(id.Value);
            if (receipts == null)
            {
                return NotFound();
            }
            ViewData["event_Id"] = new SelectList(_context.Events, "Id", "Id", receipts.event_Id);
            ViewData["user_Id"] = new SelectList(_context.Users, "Id", "Id", receipts.user_Id);
            return View(receipts);
        }

        // POST: Receipt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,user_Id,event_Id")] Receipts receipts)
        {
            if (id != receipts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receipts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptsExists(receipts.Id))
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
            await _receiptService.Save(receipts);
            ViewData["event_Id"] = new SelectList(_context.Events, "Id", "Id", receipts.event_Id);
            ViewData["user_Id"] = new SelectList(_context.Users, "Id", "Id", receipts.user_Id);
            return View(receipts);
        }

        // GET: Receipt/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Receipts == null)
            {
                return NotFound();
            }

            var receipts = await _receiptService.GetById(id.Value);
            if (receipts == null)
            {
                return NotFound();
            }

            return View(receipts);
        }

        // POST: Receipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _receiptService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptsExists(int id)
        {
            return _context.Receipts.Any(e => e.Id == id);
        }
    }
}
