using AutoMapper;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Network.Application.Common.Exceptions;
using Network.Application.Common.Interfaces.Repositories;
using Network.Domain.Models;
using Network.Infrastructure.Persistance.Contexts;

namespace Network.Infrastructure.Persistance.Repositories;

public class EfCoreRepository : IRepository
{

    private readonly NetworkDbContext _networkDbContext;
    private readonly IMapper _mapper;

    public EfCoreRepository(NetworkDbContext networkDbContext, IMapper mapper)
    {
        _networkDbContext = networkDbContext;
        _mapper = mapper;
    }
    
    public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity
    {
        return await _networkDbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<List<TEntity>> GetAllWithInclude<TEntity>(
        params Expression<Func<TEntity?, object>>[] includeProperties) where TEntity : BaseEntity
    {
        var query = IncludeProperties(includeProperties);
        return await query!.ToListAsync<TEntity>();
    }
    
    
    public async Task<TEntity?> GetById<TEntity>(int id) where TEntity : BaseEntity
    {
        return await _networkDbContext.FindAsync<TEntity>(id);
    }

    public async Task<TEntity?> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity?, object>>[] includeProperties) where TEntity : BaseEntity
    {
        var query = IncludeProperties(includeProperties);
        return await query.FirstOrDefaultAsync(entity => entity != null && entity.Id == id);
    }
    
    public async Task SaveChangesAsync()
    {
        await _networkDbContext.SaveChangesAsync();
    }

    public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        _networkDbContext.Set<TEntity>().Add(entity);
    }
    
    public async Task AddAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        await _networkDbContext.Set<TEntity>().AddAsync(entity);
    }

    public async Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity
    {
        var entity = await _networkDbContext.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            throw new ValidationException($"Object of type {typeof(TEntity)} with id {id} not found");
        }

        _networkDbContext.Set<TEntity>().Remove(entity);

        return entity;
    }

    

    private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
    {
        IQueryable<TEntity> entities = _networkDbContext.Set<TEntity>();
        foreach (var includeProperty in includeProperties)
        {
            entities = entities.Include(includeProperty);
        }
        return entities;
    }
}