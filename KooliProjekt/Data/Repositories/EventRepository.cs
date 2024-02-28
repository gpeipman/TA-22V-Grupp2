using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Queriyes
        public virtual async Task<PagedResult<Event>> List(int page, int pageSize)
        {
            var result = await Context.Events.GetPagedAsync(page, pageSize);

            return result;
        }

        public virtual async Task<Event> GetById(int id)
        {
            var result = await Context.Events.FindAsync(id);

            return result;
        }


        public virtual async Task<List<Event>> GetAll()
        {
            List<Event> allevents = new List<Event>();
            foreach (Event element in Context.Events)
            {
                allevents.Add(element);
            }

            return allevents;
        }

        public virtual async Task Save(Event list)
        {
            if (list.Id == 0)
            {
                await Context.AddAsync(list);
            }
            else
            {
                Context.Update(list);
            }
        }

        public virtual async Task Delete(int id)
        {
            var entity = await Context.Events.FindAsync(id);
            if (entity != null)
            {
                Context.Set<Event>().Remove(entity);
            }
        }

        public virtual async Task Entry(Event @event)
        {
            Context.Entry(@event).State = EntityState.Modified;
            await Context.SaveChangesAsync();


        }
        public virtual bool EventExists(int id)
        {
            return Context.Events.Any(e => e.Id == id);
        }
    }
}
