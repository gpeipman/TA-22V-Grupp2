using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class Receipt
    {
        public int Id { get; set; }
        
        public Event total_payment { get; set; }
        public IdentityUser user_id { get; set; }
    }
}