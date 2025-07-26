using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftClub.Domain.Entities;

namespace SoftClub.Persistence.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder
            .HasData(new List<City>
            {
                new City { Id = 1, Region = "Toshkent", Country = "Uzbekistan", Name = "Jetour Salon" },
                new City { Id = 2, Region = "Namangan", Country = "Uzbekistan", Name = "GM Salon" },
                new City { Id = 3, Region = "Farg'ona", Country = "Uzbekistan", Name = "BMW Salon" },
            });
    }
}