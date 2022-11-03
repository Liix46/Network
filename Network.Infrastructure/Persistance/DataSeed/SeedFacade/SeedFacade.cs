using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Network.Domain;
using Network.Infrastructure.Persistance.Contexts;
using Network.Infrastructure.Persistance.DataSeed.SeedModels;

namespace Network.Infrastructure.Persistance.DataSeed.SeedFacade;

public class SeedFacade
{
    public static async Task SeedData(NetworkDbContext networkDbContext, UserManager<User> userManager)
    {
        networkDbContext.Database.Migrate();
        
        await UsersSeed.Seed(userManager);
        await PostsSeed.Seed(networkDbContext);
        
        
    }
}