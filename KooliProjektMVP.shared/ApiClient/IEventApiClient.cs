using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjektMVP.shared.ApiClient
{
    public interface IEventApiClient : IDisposable
    {
        IList<EventModel> List();
        Task<IList<EventModel>> ListAsync();
        EventModel Get(int id);
        Task<EventModel> GetAsync(int id);
        void Save(EventModel list);
        Task SaveAsync(EventModel list);
        void Delete(int id);
        Task DeleteAsync(int id);
    }
}
