namespace SoftClub.Application.Dtos;

public class DealerDto
{
    public string Name { get; set; } = default!;

    public string Address { get; set; } = default!;

    public string Phone { get; set; } = default!;

    public string Email { get; set; } = default!;

    public decimal Rating { get; set; }

    public int CityId { get; set; }
}