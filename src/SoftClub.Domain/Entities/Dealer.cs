using SoftClub.Domain.Common.Entities;

namespace SoftClub.Domain.Entities;

public class Dealer : Entity
{
    public string Name { get; set; } = default!;

    public string Address { get; set; } = default!;

    public string Phone { get; set; } = default!;

    public string Email { get; set; } = default!;
    
    public decimal Rating { get; set; }
    
    public int CityId { get; set; }
    public City City { get; set; } = default!;

    public ICollection<Car> Cars { get; set; } = [];
}