using Network.Application.App.Users.Queries;
using Network.Domain.Models;

namespace Network.Application.Common.Interfaces;

public interface IUserIdentityService
{
    Task<User> GetCurrentUser();
}