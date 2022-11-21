using Microsoft.AspNetCore.Identity;
using Network.Domain.Models;
using Network.Infrastructure.Persistance.Contexts;
using Network.Infrastructure.Persistance.DataSeed.SeedFacade;

namespace Network.API.Extensions;

public static class HostExtensions
{
    public static async Task SeedData(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<NetworkDbContext>();
                var userManager = services.GetRequiredService<UserManager<User>>();

                await SeedFacade.SeedData(context, userManager);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }
        }
    }
}