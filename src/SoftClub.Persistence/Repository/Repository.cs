using Microsoft.EntityFrameworkCore;
using SoftClub.Domain.Common.Entities;

namespace SoftClub.Persistence.Repository;

public class Repository<TEntity, TContext>(DbContext context) : IRepository<TEntity, TContext>
    where TEntity : Entity
    where TContext : DbContext
{
    public IQueryable<TEntity> Get() =>
        context.Set<TEntity>();

    public async Task<TEntity?> GetByIdAsync(int id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = context.Set<TEntity>().AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public async Task<TEntity> CreateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);

        if (saveChanges)
            await context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        context.Update(entity);

        if (saveChanges)
            await context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<TEntity> DeleteByIdAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var exist = await context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == entity.Id)
            ?? throw new InvalidOperationException($"{nameof(TEntity)} is not exists with ID {entity.Id}");

        context.Remove(exist);

        return exist;
    }

    public Task<TEntity> DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        context.Remove(entity);

        return Task.FromResult(entity);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken);
}