using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class Event_details
    {
        public int event_id { get; set; }
        public IdentityUser user_id { get; set; }
        public bool is_payed { get; set; }
    }
}