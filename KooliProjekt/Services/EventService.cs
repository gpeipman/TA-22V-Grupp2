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
        public async Task<Event> GetById(int id)
        {
            var result = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }
        public async Task Save(Event list)
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
            var todoList = await _context.Events.FindAsync(id);
            if (todoList != null)
            {
                _context.Events.Remove(todoList);
            }

            await _context.SaveChangesAsync();
        }
    }
}