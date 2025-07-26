using SoftClub.Domain.Common.Entities;

namespace SoftClub.Domain.Entities;

public class Brand : Entity
{
    public string Name { get; set; } = default!;

    public string Country { get; set; } = default!;
    
    public string? LogoUrl { get; set; }
    
    public string? Description { get; set; }

    public ICollection<Car> Cars { get; set; } = [];
}