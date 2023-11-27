using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Event>> List(int page, int pageSize)
        {
            var result = await _context.Events.GetPagedAsync(page, pageSize);
            return result;
        }


    }
}