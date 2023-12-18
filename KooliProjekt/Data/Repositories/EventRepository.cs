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
    }
}
