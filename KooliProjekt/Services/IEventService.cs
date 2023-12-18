using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IEventService
    {
        Task<PagedResult<Event>> List(int page, int pageSize);
        Task<Event> GetById(int id);
        Task Save(Event list);
        Task Delete(int id);
    }
}
