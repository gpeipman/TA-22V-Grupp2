using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Event_details : Entity
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string user_Id { get; set; }
        public IdentityUser user { get; set; }
        public int event_Id { get; set; }

        public Event @event { get; set; }
        public bool is_payed { get; set; }
    }
}