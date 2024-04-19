using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class Event : Entity
    {
        [Display(Name = "Event's ID")]
        public int Id { get; set; }
        [Display(Name = "Event's Name")]
        public string event_name { get; set; }
        [Display(Name = "Event's Start Time")]
        public DateTime event_date_start { get; set; }
        [Display(Name = "Event's End Time")]
        public DateTime event_date_end { get; set; }
        [Display(Name = "Event's description")]
        public string event_description { get; set; } // Events program
        [Display(Name = "Event's organiser")]
        public string user_Id { get; set; }
        public IdentityUser user_ { get; set; }
        [Display(Name = "Event's maximum participants")]
        public int MaxParticipants { get; set; }
        [Display(Name = "Event's price")]
        public int? event_price { get; set; }
    }
}