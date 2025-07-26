using SoftClub.Domain.Common.Pagination;

namespace SoftClub.Application.Filters;

public class CarFilter : Pagination
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    public int? MinYear { get; set; }
    public int? MaxYear { get; set; }

    public int? MinMileage { get; set; }
    public int? MaxMileage { get; set; }

    public string? FuelType { get; set; }

    public string? Transmission { get; set; }

    public int? BrandId { get; set; }

    public int? DealerId { get; set; }

    public int? CityId { get; set; }

    public bool? IsAvailable { get; set; }
}