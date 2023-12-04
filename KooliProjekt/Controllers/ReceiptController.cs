using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;
using KooliProjekt.Services;

namespace KooliProjekt.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ReceiptService _receiptService;

        public ReceiptController(ApplicationDbContext context, ReceiptService receiptService)
        {
            _context = context;
            _receiptService = receiptService;

        }

        // GET: Receipt
        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _receiptService.List(page, 2));
        }

        // GET: Receipt/Details/5
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

        // GET: Receipt/Create
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
        public async Task<IActionResult> Create([Bind("Id,user_Id,event_Id")] Receipts receipts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receipts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["event_Id"] = new SelectList(_context.Events, "Id", "Id", receipts.event_Id);
            ViewData["user_Id"] = new SelectList(_context.Users, "Id", "Id", receipts.user_Id);
            return View(receipts);
        }

        // GET: Receipt/Edit/5
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
            ViewData["event_Id"] = new SelectList(_context.Events, "Id", "Id", receipts.event_Id);
            ViewData["user_Id"] = new SelectList(_context.Users, "Id", "Id", receipts.user_Id);
            return View(receipts);
        }

        // GET: Receipt/Delete/5
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Receipts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Receipts'  is null.");
            }
            var receipts = await _receiptService.GetById(id);
            if (receipts != null)
            {
                _context.Receipts.Remove(receipts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptsExists(int id)
        {
            return _context.Receipts.Any(e => e.Id == id);
        }
    }
}
