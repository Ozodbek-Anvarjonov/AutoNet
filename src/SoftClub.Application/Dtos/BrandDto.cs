namespace SoftClub.Application.Dtos;

public class BrandDto
{
    public string Name { get; set; } = default!;

    public string Country { get; set; } = default!;

    public string? LogoUrl { get; set; }

    public string? Description { get; set; }
}