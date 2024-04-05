using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjeks.WindowsApp.Model
{
    internal class EventRepository : IEventRepository
    {
        public IEnumerable<EventModel> GetAllEvents()
        {
            
        }

        public EventModel GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveEvent(int id, EventModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
