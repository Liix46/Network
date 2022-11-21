using Microsoft.AspNetCore.Identity;
using Network.Domain.Models;

namespace Network.Application.Common.Interfaces;

public interface IRegistrationService
{
    Task<bool> CreateAsync(User user, string password);

}