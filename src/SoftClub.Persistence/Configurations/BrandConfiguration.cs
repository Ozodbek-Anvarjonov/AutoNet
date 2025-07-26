using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftClub.Domain.Entities;

namespace SoftClub.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder
            .HasMany(entity => entity.Cars)
            .WithOne(entity => entity.Brand)
            .HasForeignKey(entity => entity.BrandId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasData(new List<Brand>
            {
                new Brand
                {
                    Id = 1,
                    Name = "Jetour",
                    Country = "China",
                    LogoUrl = "https://example.com/logos/jetour.png",
                    Description = "Jetour is a brand under Chery Holding focusing on affordable SUVs."
                },
                new Brand
                {
                    Id = 2,
                    Name = "Chevrolet",
                    Country = "USA",
                    LogoUrl = "https://example.com/logos/chevrolet.png",
                    Description = "Chevrolet is one of America's most iconic automobile brands under General Motors."
                },
                new Brand
                {
                    Id = 3,
                    Name = "BMW",
                    Country = "Germany",
                    LogoUrl = "https://example.com/logos/bmw.png",
                    Description = "BMW is a German multinational company producing luxury vehicles and motorcycles."
                }
            });
    }
}