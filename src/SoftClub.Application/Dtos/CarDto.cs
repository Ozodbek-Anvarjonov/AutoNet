namespace SoftClub.Application.Dtos;

public class CarDto
{
    public string Model { get; set; } = default!;

    public int Year { get; set; }

    public decimal Price { get; set; }

    public int Mileage { get; set; }

    public string Color { get; set; } = default!;

    public string FuelType { get; set; } = default!;

    public string Transmission { get; set; } = default!;

    public int DealerId { get; set; }
   
    public int BrandId { get; set; }

    public bool IsAvailable { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }
}
