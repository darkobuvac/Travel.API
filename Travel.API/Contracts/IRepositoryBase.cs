using System.Linq.Expressions;

namespace Travel.API.Contracts;

public interface IRepositoryBase<TEntity>
    where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(
        int Id,
        TEntity entity,
        CancellationToken cancellationToken = default
    );
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByConditionAsync(
        Expression<Func<TEntity, bool>> condition,
        CancellationToken cancellationToken = default
    );
    Task<IList<TEntity>> GetAllsync(CancellationToken cancellationToken = default);
    Task SaveAsync(CancellationToken cancellationToken = default);
}
