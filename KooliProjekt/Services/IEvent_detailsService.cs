using KooliProjekt.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public interface IEvent_detailsService
    {
        Task<PagedResult<Event_details>> List(int page, int pageSize);

        Task<Event_details> GetById(int id);
        Task Save(Event_details list);
        Task<List<Event_details>> GetEvent_details(string loggedInUsername);
        Task Delete(int id);
    }
}
