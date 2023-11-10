using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace KooliProjekt.Data
{
    public static class SeedData
    {
        public static void Generate(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            AddUsers(userManager);
            AddEvent(context);
        }

        private static void AddUsers(UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser();
            user.UserName = "mina@example.com";
            user.EmailConfirmed = true;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "Polükas2013*");

            userManager.CreateAsync(user).Wait();
        }

        private static void AddEvent(ApplicationDbContext context) 
        { 
            if(context.Events.Count() > 0) 
            {
                return;
            }

            var @event = new Event();
            @event.event_name = "UN Summit";

            context.Add(@event);
            context.SaveChanges();
        }
    }
}
