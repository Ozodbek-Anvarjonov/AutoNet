using Microsoft.EntityFrameworkCore;
using SoftClub.Domain.Entities;
using System.Reflection;

namespace SoftClub.Persistence.DataContexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): DbContext(options)
{
    public DbSet<Brand> Brands { get; set; }

    public DbSet<Car> Cars { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Dealer> Dealers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}