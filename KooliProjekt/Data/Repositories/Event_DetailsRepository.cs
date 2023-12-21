using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace KooliProjekt.Data.Repositories
{
    public class Event_detailsRepository : BaseRepository<Event_details>, IEvent_DetailsRepository
    {
        public Event_detailsRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Queriyes
        public virtual async Task<PagedResult<Event_details>> List(int page, int pageSize)
        {
            var result = await Context.Event_Details
                .Include(o => o.user_)
                .Include(o => o.event_)
                .GetPagedAsync(page, pageSize);

            return result;
        }

        public virtual async Task<Event_details> GetById(int id)
        {
            var result = await Context.Event_Details.FindAsync(id);
        
            return result;
        }

        public virtual async Task Save(Event_details entity)
        {
            if (entity.Id == 0)
            {
                await Context.AddAsync(entity);
            }
            else
            {
                Context.Update(entity);
            }
        }

        public virtual async Task Delete(int id)
        {
            var entity = await Context.Event_Details.FindAsync(id);
            if (entity != null)
            {
                Context.Event_Details.Remove(entity);
            }
        }
    }
}
