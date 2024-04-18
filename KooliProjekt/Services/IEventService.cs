using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IEventService
    {
        Task<PagedResult<Event>> List(int page, int pageSize);
        Task<Event> GetById(int id);
        Task Save(Event list);
        Task Delete(int id);
        Task Entry(Event @event);
        bool EventExists(int id);
        Task<IEnumerable<LookupItem>> Lookup();
        List<Event> GetAllEvents();
    }
}
