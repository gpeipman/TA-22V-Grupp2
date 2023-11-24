using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace KooliProjekt.Data
{
    public static class SeedData
    {
        public static void Generate(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AddUsers(userManager);
            AddEvent(context);
            AddRole(roleManager);
        }

        private static void AddEvent(RoleManager<IdentityRole> roleManager)
        {
            throw new NotImplementedException();
        }

        private static void AddUsers(UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser();
            user.UserName = "mina@example.com";
            user.EmailConfirmed = true;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "Polükas2013*");
            user.Id = "Admin";

            userManager.CreateAsync(user).Wait();
        }

        private static void AddEvent(ApplicationDbContext context)
        {
            if (context.Events.Count() > 0)
            {
                return;
            }

            var @event = new Event();
            @event.event_name = "UN Summit";

            context.Add(@event);
            context.SaveChanges();
        }
        private static void AddRole(RoleManager<IdentityRole> roleManager)
        {
            var newRole = new IdentityRole();
            newRole.Id = "1";
            newRole.Name = "Admin";


            roleManager.CreateAsync(newRole).Wait();

        }

    }
}
