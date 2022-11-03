using System.Linq.Expressions;
using Network.Domain;

namespace Network.Application.Common.Interfaces.Repositories;

public interface IRepository
{
    Task<TEntity?> GetById<TEntity>(int id) where TEntity : BaseEntity;
    Task<TEntity?> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity?, object>>[] includeProperties) where TEntity : BaseEntity;
    Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity;

    Task<List<TEntity>> GetAllWithInclude<TEntity>(
        params Expression<Func<TEntity?, object>>[] includeProperties) where TEntity : BaseEntity;
    Task SaveChangesAsync();
    void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;

    Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity;
}