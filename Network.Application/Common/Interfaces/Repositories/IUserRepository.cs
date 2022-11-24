using System.Linq.Expressions;
using Network.Application.App.Users.Response;
using Network.Domain.Models;

namespace Network.Application.Common.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetById(int id);
    Task<User?> GetByUsername(string username);
    Task<User?> GetByIdWithInclude(int id, params Expression<Func<User?, object>>[] includeProperties);
    Task<User?> GetByUsernameWithInclude(string username, params Expression<Func<User?, object>>[] includeProperties);
    Task<List<User>> GetAll();
    Task<List<User>> GetAllWithInclude( params Expression<Func<User?, object>>[] includeProperties);
    Task SaveChangesAsync();
    Task UpdateChangesAsync(User user);
    Task<User?> Delete(int id);

    Task<int?> GetCountPosts(string username);
    Task<int?> GetCountFollowers(string username);

    Task<int?> GetCountFollowing(string username);

    Task RemoveAvatarImage(string username);

    Task<IEnumerable<ImageDto>> GetUserImages(string username);

    Task<IEnumerable<UserSearchDto>> GetSearchUsersByUsername(string searchString);

    Task<bool> AddFollowing(string usernameFrom, string usernameTo);

    Task<IQueryable<User>> GetFollowings();
}