using Microsoft.AspNetCore.Identity;

namespace Store
{
    public class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("danial.nouri20@gmail.com").Result==null )
            {
                var user = new IdentityUser
                {
                    UserName = "danial.nouri20@gmail.com",
                    Email = "danial.nouri20@gmail.com"
                };
                var result = userManager.CreateAsync(user,"Danial@gmail123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }   
            if (userManager.FindByNameAsync("user1.nouri20@gmail.com").Result==null )
            {
                var user = new IdentityUser
                {
                    UserName = "user1.nouri20@gmail.com",
                    Email = "user1.nouri20@gmail.com"
                };
                var result = userManager.CreateAsync(user,"user1@gmail123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }   
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
            
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}