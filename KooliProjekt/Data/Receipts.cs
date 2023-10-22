using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class Receipts
    {
        public int Id { get; set; }   
        public int event_Id { get; set; }
        public Event event_ { get; set; }

    }
}