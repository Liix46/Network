using System.Reflection;
using System.Security.Principal;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Network.Application.App.Auth.Commands;
using Network.Application.Common.Interfaces;
using Network.Application.Common.Interfaces.Repositories;
using Network.Domain.Models;
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

        services.AddScoped<IRepository, EfCoreRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IRegistrationService, RegistrationService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<ISignOutService, SignOutService>();
        
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
        
        services.AddTransient<IUserIdentityService, UserIdentityService>();
        services.AddTransient<IFileService, FileService>();
        
        return services;
    }
}