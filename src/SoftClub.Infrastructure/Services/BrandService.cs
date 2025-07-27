using Microsoft.EntityFrameworkCore;
using SoftClub.Application.Services;
using SoftClub.Domain.Common.Pagination;
using SoftClub.Domain.Entities;
using SoftClub.Infrastructure.Extensions;
using SoftClub.Persistence.DataContexts;
using SoftClub.Persistence.Repository;

namespace SoftClub.Infrastructure.Services;

public class BrandService(IRepository<Brand, ApplicationDbContext> repository) : IBrandService
{
    public async Task<List<Brand>> GetAsync(Pagination filter, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = repository.Get();

        if (asNoTracking)
            query = query.AsNoTracking();


        return await query.ToPaginateAsync(filter, cancellationToken);
    }

    public async Task<Brand> GetByIdAsync(int id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var exist = await repository.GetByIdAsync(id, asNoTracking, cancellationToken)
            ?? throw new InvalidOperationException($"Car does not exist with ID {id}");

        return exist;
    }

    public async Task<Brand> CreateAsync(Brand brand, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var entity = await repository.CreateAsync(brand, saveChanges, cancellationToken);

        return entity;
    }

    public async Task<Brand> UpdateAsync(int id, Brand brand, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var exist = await GetByIdAsync(id, cancellationToken: cancellationToken);

        exist.Country = brand.Country;
        exist.Name = brand.Name;
        exist.Description = brand.Description;
        exist.LogoUrl = brand.LogoUrl;

        if (saveChanges)
            await repository.SaveChangesAsync(cancellationToken);

        return exist;
    }

    public async Task<bool> DeleteByIdAsync(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var exist = await GetByIdAsync(id, cancellationToken: cancellationToken);

        await repository.DeleteAsync(exist);

        return exist is not null ? true : false;
    }
}