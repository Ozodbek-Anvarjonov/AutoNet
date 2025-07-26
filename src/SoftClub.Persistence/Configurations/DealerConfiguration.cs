using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftClub.Domain.Entities;

namespace SoftClub.Persistence.Configurations;

public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
{
    public void Configure(EntityTypeBuilder<Dealer> builder)
    {
        builder
            .HasMany(entity => entity.Cars)
            .WithOne(entity => entity.Dealer)
            .HasForeignKey(entity => entity.DealerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(entity => entity.City)
            .WithMany(entity => entity.Dealers)
            .HasForeignKey(entity => entity.CityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasData(new List<Dealer>
            {
                new Dealer
                {
                    Id = 1,
                    Name = "Jetour Dealer",
                    Address = "Toshkent sh., Chilonzor tumani",
                    Phone = "+998901234567",
                    Email = "jetour@dealer.uz",
                    Rating = 4.5m,
                    CityId = 1
                },
                new Dealer
                {
                    Id = 2,
                    Name = "GM Uz Dealer",
                    Address = "Namangan sh., Yangi shahar ko'chasi",
                    Phone = "+998911234567",
                    Email = "gm@dealer.uz",
                    Rating = 4.2m,
                    CityId = 2
                },
                new Dealer
                {
                    Id = 3,
                    Name = "BMW Farg'ona",
                    Address = "Farg'ona sh., Mustaqillik ko'chasi",
                    Phone = "+998931234567",
                    Email = "bmw@dealer.uz",
                    Rating = 4.8m,
                    CityId = 3
                }
            });
    }
}