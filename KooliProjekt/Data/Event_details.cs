using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class Event_details
    {
        public int Id { get; set; }
        public IdentityUser user_ { get; set; }
        public bool is_payed { get; set; }
    }
}