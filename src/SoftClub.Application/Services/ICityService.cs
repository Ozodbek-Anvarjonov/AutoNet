using SoftClub.Application.Filters;
using SoftClub.Domain.Common.Pagination;
using SoftClub.Domain.Entities;

namespace SoftClub.Application.Services;

public interface ICityService
{
    Task<List<City>> GetAsync(Pagination filter, bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<City> GetByIdAsync(int id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<City> CreateAsync(City city, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<City> UpdateAsync(int id, City city, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<bool> DeleteByIdAsync(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
}