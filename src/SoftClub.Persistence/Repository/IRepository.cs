using Microsoft.EntityFrameworkCore;

namespace SoftClub.Persistence.Repository;

public interface IRepository<TEntity, TContext>
{
    IQueryable<TEntity> Get();

    Task<TEntity?> GetByIdAsync(int id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<TEntity> CreateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<TEntity> DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<TEntity> DeleteByIdAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}