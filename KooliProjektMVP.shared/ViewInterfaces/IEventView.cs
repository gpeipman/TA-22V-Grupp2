using KooliProjektMVP.shared.ApiClient;
using KooliProjektMVP.shared.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjektMVP.shared.ViewInterfaces
{
    public interface IEventView
    {
        IList<EventModel> Lists { get; set; }

        int SelectedEventId { get; set; }
        string SelectedItemName { get; set; }

        DateTime Selected_event_date_start { get; set; }

        DateTime Selected_event_date_end { get; set; }

        string Selected_event_description { get; set; } // Events program

        string Selected_user_Id { get; set; }

        int Selected_MaxParticipants { get; set; }

        int? Selected_event_price { get; set; }

        EventPresenter Presenter { set; }
    }
}
