using SoftClub.Application.Filters;
using SoftClub.Domain.Common.Pagination;
using SoftClub.Domain.Entities;

namespace SoftClub.Application.Services;

public interface IDealerService
{
    Task<List<Dealer>> GetAsync(DealerFilter filter, bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<Dealer> GetByIdAsync(int id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<Dealer> CreateAsync(Dealer dealer, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<Dealer> UpdateAsync(int id, Dealer dealer, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<Dealer> DeleteByIdAsync(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
}