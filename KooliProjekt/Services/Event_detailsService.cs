using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;



namespace KooliProjekt.Services
{
    public class Event_detailsService
    {
        private readonly ApplicationDbContext _context;

        public Event_detailsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Event_details>> List(int page, int pageSize)
        {
            var result = await _context.Event_Details.GetPagedAsync(page, pageSize);
            return result;
        }
        public async Task<Event_details> GetById(int id)
        {
            var result = await _context.Event_Details.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }
        public async Task Save(Event_details list)
        {
            if (list.Id == 0)
            {
                _context.Add(list);
            }
            else
            {
                _context.Update(list);
            }

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var Event_details = await _context.Event_Details.FindAsync(id);
            if (Event_details != null)
            {
                _context.Event_Details.Remove(Event_details);
            }

            await _context.SaveChangesAsync();
        }
    }
}