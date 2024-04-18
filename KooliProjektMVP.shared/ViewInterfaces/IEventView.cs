using KooliProjektMVP.shared.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjektMVP.shared.ViewInterfaces
{
    internal interface IEventView
    {
        IList<EventModel> Lists { get; set; }

        int SelectedEventId { get; set; }
        string SelectedItemName { get; set; }

        DateTime event_date_start { get; set; }

        DateTime event_date_end { get; set; }

        string event_description { get; set; } // Events program

        string user_Id { get; set; }

        int MaxParticipants { get; set; }

        int? event_price { get; set; }

        ToDoListsPresenter Presenter { set; }
    }
}
