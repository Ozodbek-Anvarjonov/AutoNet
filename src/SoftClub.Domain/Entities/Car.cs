using SoftClub.Domain.Common.Entities;

namespace SoftClub.Domain.Entities;

public class Car : Entity
{
    public string Model { get; set; } = default!;

    public int Year { get; set; }

    public decimal Price { get; set; }

    public int Mileage { get; set; }

    public string Color { get; set; } = default!;

    public string FuelType { get; set; } = default!;

    public string Transmission { get; set; } = default!;

    public int DealerId { get; set; }
    public Dealer Dealer { get; set; } = default!;

    public int BrandId { get; set; }
    public Brand Brand { get; set; } = default!;

    public bool IsAvailable { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }
}