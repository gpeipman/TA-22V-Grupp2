using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjeks.WindowsApp.Model
{
    internal interface IEventRepository
    {
        IEnumerable<EventModel> GetAllEvents();

        EventModel GetEvent(int id);

        void SaveEvent(int id, EventModel customer);
    }
}
