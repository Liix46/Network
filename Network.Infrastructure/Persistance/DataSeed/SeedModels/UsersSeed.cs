using Microsoft.AspNetCore.Identity;
using Network.Domain;

namespace Network.Infrastructure.Persistance.DataSeed.SeedModels;

public class UsersSeed
{
    public static async Task Seed(UserManager<User> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new User()
            {
                //Id = 1,
                Name = "Alex Boichev",
                UserName = "Liix46",
                Bio = "I'm in black, but brighter than you",
                Email = "alexboichev46@gmail.com",
                PhoneNumber = "380964038548",
                Gender = Gender.Male,
                //UrlMainImage = null
            };
            var newUser = await userManager.CreateAsync(user, "Password123#");
        }
    }
}