using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;
using KooliProjekt.Services;

namespace KooliProjekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventAPIController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IEvent_detailsService _event_DetailsService;
        private readonly IReceiptService _receiptService;

        public EventAPIController(IEventService eventService, IEvent_detailsService event_DetailsService, IReceiptService receiptService)
        {
            _eventService = eventService;
            _event_DetailsService = event_DetailsService;
            _receiptService = receiptService;
        }

        // GET: api/EventAPI
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _eventService.;
        }*/

        // GET: api/EventAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _eventService.GetById(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/EventAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            try
            {
                await _eventService.Entry(@event);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_eventService.EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EventAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostEvent(Event @event)
        {
            await _eventService.Save(@event);

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }
        // DELETE: api/EventAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventService.Delete(id);

            return NoContent();
        }
    }
}
