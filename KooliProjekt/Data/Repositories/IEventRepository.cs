using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Data.Repositories
{
    public interface IEventRepository
    {
        Task<PagedResult<Event>> List(int page, int pageSize);
        Task<Event> GetById(int id);
        Task Save(Event list);
        Task Delete(int id);
        Task Entry(Event @event);
        bool EventExists(int id);
        List<Event> GetAll();
        Task<IEnumerable<LookupItem>> Lookup();
    }
}