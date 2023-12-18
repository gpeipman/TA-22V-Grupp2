using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class Receipts : Entity
    {
        public int Id { get; set; }
        public string user_Id { get; set; }
        public IdentityUser user_ { get; set; }
        public int event_Id { get; set; }
        public Event event_ { get; set; }

    }
}