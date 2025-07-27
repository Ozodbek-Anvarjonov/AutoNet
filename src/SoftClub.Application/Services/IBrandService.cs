using SoftClub.Application.Filters;
using SoftClub.Domain.Common.Pagination;
using SoftClub.Domain.Entities;

namespace SoftClub.Application.Services;

public interface IBrandService
{
    Task<List<Brand>> GetAsync(Pagination filter, bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<Brand> GetByIdAsync(int id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<Brand> CreateAsync(Brand brand, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<Brand> UpdateAsync(int id, Brand brand, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<Brand> DeleteByIdAsync(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
}