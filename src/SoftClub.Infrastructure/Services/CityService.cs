using Microsoft.EntityFrameworkCore;
using SoftClub.Application.Services;
using SoftClub.Domain.Common.Pagination;
using SoftClub.Domain.Entities;
using SoftClub.Infrastructure.Extensions;
using SoftClub.Persistence.DataContexts;
using SoftClub.Persistence.Repository;

namespace SoftClub.Infrastructure.Services;

public class CityService(IRepository<City, ApplicationDbContext> repository) : ICityService
{
    public async Task<List<City>> GetAsync(Pagination filter, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = repository.Get();

        if (asNoTracking)
            query = query.AsNoTracking();


        return await query.ToPaginateAsync(filter, cancellationToken);
    }

    public async Task<City> GetByIdAsync(int id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var exist = await repository.GetByIdAsync(id, asNoTracking, cancellationToken)
            ?? throw new InvalidOperationException($"Car does not exist with ID {id}");

        return exist;
    }

    public async Task<City> CreateAsync(City city, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var entity = await repository.CreateAsync(city, saveChanges, cancellationToken);

        return entity;
    }

    public async Task<City> UpdateAsync(int id, City city, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var exist = await GetByIdAsync(id, cancellationToken: cancellationToken);

        exist.Name = city.Name;
        exist.Region = city.Region;
        exist.Country = city.Country;

        if (saveChanges)
            await repository.SaveChangesAsync(cancellationToken);

        return exist;
    }

    public async Task<City> DeleteByIdAsync(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var exist = await GetByIdAsync(id, cancellationToken: cancellationToken);

        await repository.DeleteAsync(exist);

        return exist;
    }
}