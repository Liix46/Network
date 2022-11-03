using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Network.Application.Common.Interfaces;
using Network.Application.Common.Interfaces.Repositories;
using Network.Domain;
using Network.Domain.Auth;
using Network.Infrastructure.Identity;
using Network.Infrastructure.Persistance.Contexts;
using Network.Infrastructure.Persistance.Repositories;

namespace Network.Infrastructure.Persistance.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NetworkDbContext>(optionBuilder =>
        {
            optionBuilder.UseSqlServer(configuration.GetConnectionString("NetworkConnection"));
        });

        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredLength = 8;
        })
        .AddEntityFrameworkStores<NetworkDbContext>();

        services.AddScoped<IRepository, EFCoreRepository>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IRegistrationService, RegistrationService>();
        services.AddTransient<ITokenService, TokenService>();

        return services;
    }
}