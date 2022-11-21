using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Network.Application.App.Users.Queries;
using Network.Application.Common.Interfaces;
using Network.Domain.Models;
using Network.Infrastructure.Persistance.Contexts;

namespace Network.Infrastructure.Identity;

public class UserIdentityService : IUserIdentityService
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserIdentityService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<User> GetCurrentUser()
    {
        if (_httpContextAccessor.HttpContext != null)
        {
            var User = _httpContextAccessor.HttpContext.User;

            var email = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value; 
            var user = await _userManager
                .Users
                .SingleOrDefaultAsync(x => x.Email == email);
            return user;
        }
        else
        {
            return new User();
        }
    }
}