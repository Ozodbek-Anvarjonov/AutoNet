using SoftClub.Domain.Common.Entities;

namespace SoftClub.Domain.Entities;

public class City : Entity
{
    public string Name { get; set; } = default!;
    
    public string Region { get; set; } = default!;
    
    public string Country { get; set; } = default!;

    public ICollection<Dealer> Dealers { get; set; } = [];
}