using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Network.Domain.Models;
using Network.Infrastructure.Persistance.Contexts;
using Network.Infrastructure.Persistance.DataSeed.SeedModels;

namespace Network.Infrastructure.Persistance.DataSeed.SeedFacade;

public class SeedFacade
{
    public static async Task SeedData(NetworkDbContext networkDbContext, UserManager<User> userManager)
    {
        await networkDbContext.Database.MigrateAsync();

        await UsersSeed.Seed(userManager);
        await PostsSeed.Seed(networkDbContext);
        await ImageSeed.Seed(networkDbContext);
    }
}