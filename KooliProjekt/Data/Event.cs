using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string event_name { get; set; }
        public DateTime event_date { get; set; }
        public string event_description { get; set; }
        public User organizers_id { get; set; }
        public int event_price { get; set; }
    }
}