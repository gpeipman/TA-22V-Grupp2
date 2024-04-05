using KooliProjeks.WindowsApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjeks.WindowsApp.View
{
    internal interface IEventView
    {
        IList<EventModel> EventList { get; set; }

        int SelectedEvent { get; set; }
        public int Id { get; set; }
        public string event_name { get; set; }
        public DateTime event_date_start { get; set; }
        public DateTime event_date_end { get; set; }
        public string event_description { get; set; } // Events program
        public string user_Id { get; set; }
        public int MaxParticipants { get; set; }
        public int? event_price { get; set; }

        //EventPresenter Presenter { get; set; }
    }
}
