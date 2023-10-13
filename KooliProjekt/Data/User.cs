using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class User
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string hashed_password { get; set; }
        public string? surname { get; set; }
        public int? telephone_number { get; set; }
        public DateTime? registration_date { get; set; }
        public string? gender { get; set; }
        public bool is_admin { get; set; }
        public string? users_email { get; set; }

        public IList<Receipt> Invoices { get; set; } // <-- Kliendile saadetud arved         
        public User() // <-- lastake käima kui tehakse new Customer        
        {             
            Receipt = new List<Receipt>(); // <-- Kliendile esitatud arvete loend        
        }
    }
}