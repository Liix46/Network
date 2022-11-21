using Network.Domain.Models;

namespace Network.Application.Common.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(User user);
}