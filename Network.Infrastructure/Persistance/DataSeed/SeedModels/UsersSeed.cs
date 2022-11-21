using Microsoft.AspNetCore.Identity;
using Network.Domain.Models;

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
                UrlMainImage = "uploads/Liix46/avatars/40e44e13-6719-1edc-9390-a47f2d19f979.jpeg"
            };
            var user2 = new User()
            {
                Name = "Dwayne Johnson",
                UserName = "therock",
                Bio = "founder",
                Email = "therock46@gmail.com",
                PhoneNumber = "380984008548",
                Gender = Gender.Male, 
                UrlMainImage = "uploads/therock/avatars/8f0b0f84-7870-6085-b3b2-cdcdf991a24d.jpeg"
            };
             await userManager.CreateAsync(user, "Password123#");
             await userManager.CreateAsync(user2, "Password123#");
        }
    }
}