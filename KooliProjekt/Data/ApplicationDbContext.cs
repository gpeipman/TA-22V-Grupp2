using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Event_details> Event_Details { get; set; } = default!;
        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<Receipts> Receipts { get; set; } = default!;
    }
}