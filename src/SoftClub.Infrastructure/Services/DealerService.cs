using Microsoft.EntityFrameworkCore;
using SoftClub.Application.Services;
using SoftClub.Domain.Common.Pagination;
using SoftClub.Domain.Entities;
using SoftClub.Infrastructure.Extensions;
using SoftClub.Persistence.DataContexts;
using SoftClub.Persistence.Repository;

namespace SoftClub.Infrastructure.Services;

public class DealerService(IRepository<Dealer, ApplicationDbContext> repository) : IDealerService
{
    public async Task<List<Dealer>> GetAsync(Pagination filter, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = repository.Get();

        if (asNoTracking)
            query = query.AsNoTracking();


        return await query.ToPaginateAsync(filter);
    }

    public async Task<Dealer> GetByIdAsync(int id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var exist = await repository.GetByIdAsync(id, asNoTracking, cancellationToken)
            ?? throw new InvalidOperationException($"Car does not exist with ID {id}");

        return exist;
    }

    public async Task<Dealer> CreateAsync(Dealer dealer, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var entity = await repository.CreateAsync(dealer, saveChanges, cancellationToken);

        return entity;
    }

    public async Task<Dealer> UpdateAsync(int id, Dealer dealer, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var exist = await GetByIdAsync(id, cancellationToken: cancellationToken);

        exist.Name = dealer.Name;
        exist.Address = dealer.Address;
        exist.Phone = dealer.Phone;
        exist.Email = dealer.Email;
        exist.Rating = dealer.Rating;
        exist.CityId = dealer.CityId;

        if (saveChanges)
            await repository.SaveChangesAsync(cancellationToken);

        return exist;
    }

    public async Task<Dealer> DeleteByIdAsync(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var exist = await GetByIdAsync(id, cancellationToken: cancellationToken);

        await repository.DeleteAsync(exist);

        return exist;
    }
}