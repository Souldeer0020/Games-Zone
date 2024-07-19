
namespace Games_Zone.Data
{
    public class DatabaseInitializer
    {
        public static async Task seedDataAsync(UserManager<IdentityUser>? userManager,
            RoleManager<IdentityRole>? roleManager)
        {
            if(userManager == null || roleManager == null)
            {
                Console.WriteLine("User manager or Role manager is null");
                return;
            }

            var exists = await roleManager.RoleExistsAsync("admin");
            if (!exists)
            {
                Console.WriteLine("admin role does not exist and will be created");
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            exists = await roleManager.RoleExistsAsync("client");
            if (!exists)
            {
                Console.WriteLine("client role does not exist and will be created");
                await roleManager.CreateAsync(new IdentityRole("client"));
            }

            var adminUsers = await userManager.GetUsersInRoleAsync("admin");
            if (adminUsers.Any())
            {
                Console.WriteLine("admin user already exists");
                return;
            }

            var user = new IdentityUser
            {
                UserName = "admin1@gameZone.com",
                Email = "admin1@gameZone.com"
            };

            string defaultPassword = "Admin123*";
            
            var result = await userManager.CreateAsync(user,defaultPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "admin");
                Console.WriteLine("admin user created successfully, please update the initial passwords");
                Console.WriteLine($"Email :{user.Email}, Initial password :{defaultPassword}");
            }
            else
            {
                Console.WriteLine($"Unable to create admin user :{result.Errors.First().Description}");
            }

        }

    }
}
