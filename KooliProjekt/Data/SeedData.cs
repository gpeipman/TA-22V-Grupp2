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
            AddAdmin(userManager);
        }
 
        private static void AddEvent(RoleManager<IdentityRole> roleManager)
        {
            throw new NotImplementedException();
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
 
        private static void AddUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.Users.Count() > 0)
            {
                return;
            }
            IdentityUser user = new IdentityUser();
            user.UserName = "mina@example.com";
            user.EmailConfirmed = true;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "Polükas2013*");
            user.Email = user.UserName;
            user.NormalizedEmail = user.Email.ToUpper();
            user.Id = "1";
 
            userManager.CreateAsync(user).Wait();
            userManager.AddToRoleAsync(user, "Admin");
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
        private static void AddAdmin(UserManager<IdentityUser> userManager) // Короче где-то в этом методе ошибка
        {

            var user = userManager.FindByIdAsync("1").Result;
 
            userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
        }
    }
}