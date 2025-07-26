using SoftClub.Application.Filters;
using SoftClub.Domain.Entities;

namespace SoftClub.Application.Services;

public interface ICarService
{
    Task<List<Car>> GetAsync(CarFilter filter, bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<Car> GetByIdAsync(int id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<Car> CreateAsync(Car car, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<Car> UpdateAsync(int id, Car car, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<Car> DeleteByIdAsync(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
}