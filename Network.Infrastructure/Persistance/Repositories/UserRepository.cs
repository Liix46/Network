using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Network.Application.App.Users.Response;
using Network.Application.Common.Exceptions;
using Network.Application.Common.Interfaces.Repositories;
using Network.Domain.Models;
using Network.Infrastructure.Persistance.Contexts;

namespace Network.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly NetworkDbContext _networkDbContext;
    private readonly IMapper _mapper;
    private readonly IRepository _entityRepository;
    private readonly UserManager<User> _userManager;

    public UserRepository(NetworkDbContext networkDbContext, IMapper mapper, IRepository repository, UserManager<User> userManager)
    {
        _networkDbContext = networkDbContext;
        _mapper = mapper;
        _entityRepository = repository;
        _userManager = userManager;
    }


    public async Task<User?> GetById(int id)
    {
        return await _networkDbContext.FindAsync<User>(id);
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _networkDbContext.Users.FirstOrDefaultAsync(entity => entity != null && entity.UserName == username);
    }

    public async Task<User?> GetByIdWithInclude(int id, params Expression<Func<User?, object>>[] includeProperties)
    {
        var query = IncludeProperties(includeProperties);
        return await query.FirstOrDefaultAsync(entity => entity != null && entity.Id == id);
    }

    public async Task<User?> GetByUsernameWithInclude(string username, params Expression<Func<User?, object>>[] includeProperties)
    {
        var query = IncludeProperties(includeProperties);
        return await query.FirstOrDefaultAsync(entity => entity != null && entity.UserName == username);
    }

    public async Task<List<User>> GetAll()
    {
        return await _networkDbContext.Set<User>().ToListAsync();
    }

    public async Task<List<User>> GetAllWithInclude(params Expression<Func<User?, object>>[] includeProperties)
    {
        var query = IncludeProperties(includeProperties);
        return await query!.ToListAsync<User>();
    }

    public async Task SaveChangesAsync()
    {
        await _networkDbContext.SaveChangesAsync();
    }

    public async Task UpdateChangesAsync(User user)
    {
        await _userManager.UpdateAsync(user);
        await SaveChangesAsync();
    }

    public async Task<User?> Delete(int id)
    {
        var entity = await _networkDbContext.Set<User>().FindAsync(id);
        if (entity == null)
        {
            throw new ValidationException($"Object of type User with id {id} not found");
        }

        _networkDbContext.Set<User>().Remove(entity);

        return entity;
    }

    public async Task<int?> GetCountPosts(string username)
    {
        var users =  IncludeProperties(user => user.Posts);
        var user = await users.FirstOrDefaultAsync(entity => entity != null && entity.UserName == username);

         return user?.Posts.Count;
    }

    public async Task<int?> GetCountFollowers(string username)
    {
        var users =  IncludeProperties(user => user.Followers);
        var user = await users.FirstOrDefaultAsync(entity => entity != null && entity.UserName == username);
        return user?.Followers.Count;
    }

    public async Task<int?> GetCountFollowing(string username)
    {
        var users =  IncludeProperties(user => user.Followings);
        var user = await users.FirstOrDefaultAsync(entity => entity != null && entity.UserName == username);
        return user?.Followings.Count;
    }

    public async Task RemoveAvatarImage(string username)
    {
        var user = await _networkDbContext.Users.FirstOrDefaultAsync(entity => entity != null && entity.UserName == username);
        user.UrlMainImage = "";
        await UpdateChangesAsync(user);
    }

    public async Task<IEnumerable<ImageDto>> GetUserImages(string username)
    {
        var user = await _networkDbContext.Users.FirstOrDefaultAsync(entity => entity != null && entity.UserName == username);
        var posts = await _entityRepository.GetAllWithInclude<Post>(post => post.Image);
        posts = posts.Where(p => p.UserId == user.Id).ToList();
        var images = posts.Select(p => p.Image).OrderByDescending(i => i.Post.DatePublication);
        var imagedtos = _mapper.Map<IEnumerable<ImageDto>>(images);
        return imagedtos;
    }

    public async Task<IEnumerable<UserSearchDto>> GetSearchUsersByUsername(string searchString)
    {
        var users = _networkDbContext.Users.Where(u => u.UserName.IndexOf(searchString) != -1);
        var mapUsers = _mapper.Map<IEnumerable<UserSearchDto>>(users);
        return mapUsers;
    }

    public async Task<bool> AddFollowing(string usernameFrom, string usernameTo)
    {
        var userFrom = await GetByUsername(usernameFrom);
        var userTo = await GetByUsername(usernameTo);

        Following following = new() {UserId = userFrom.Id, FollowingId =  userTo.Id};
        Follower follower = new() {UserId = userTo.Id, FollowerId = userFrom.Id};
        
        
         await _networkDbContext.Followings.AddAsync(following);
         await _networkDbContext.Followers.AddAsync(follower);
         
        
         // userFrom.Followings.Add(following);
         // userTo.Followers.Add(follower);
         //await SaveChangesAsync();
        
        return true;
    }

    public async Task<IQueryable<User>> GetFollowings()
    {
        return IncludeProperties(user => user.Followings);
    }


    private IQueryable<User> IncludeProperties(params Expression<Func<User, object>>[] includeProperties)
    {
        IQueryable<User> entities = _networkDbContext.Set<User>();
        foreach (var includeProperty in includeProperties)
        {
            entities = entities.Include(includeProperty);
        }
        return entities;
    }
    
}