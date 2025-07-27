using SoftClub.Domain.Common.Pagination;

namespace SoftClub.Application.Filters;

public class DealerFilter : Pagination
{
    public int? CityId { get; set; }
}