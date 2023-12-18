using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IEvent_detailsService
    {
        Task<PagedResult<Event_details>> List(int page, int pageSize);
        Task<Event_details> GetById(int id);
        Task Save(Event_details list);
        Task Delete(int id);
    }
}
