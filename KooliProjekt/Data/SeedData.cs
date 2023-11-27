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
            if (roleManager.Roles.Count() > 0)
            {
                return;
            }

            var newRole = new IdentityRole();
            newRole.Name = "Admin";
            newRole.Id = "1";

            roleManager.CreateAsync(newRole).Wait();
        }

        private static void AddAdmin(IdentityUserRole<IdentityRole> settingRoles) // Короче где-то в этом методе ошибка
        {

            var newUserWithRole = new IdentityRole();
            newUserWithRole.UserId = "5a2d63ae-774e-4175-aa63-e53b56bdb016";
            newUserWithRole.RoleId = "1";

            //settingRoles.CreateAsync(newUserWithRole).Wait();

        } 

    }
}
