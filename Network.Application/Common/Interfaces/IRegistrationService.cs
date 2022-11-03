using Network.Domain;

namespace Network.Application.Common.Interfaces;

public interface IRegistrationService
{
    Task<bool> CreateAsync(User user, string password);
}