using Microsoft.EntityFrameworkCore;
using SoftClub.Application.Filters;
using SoftClub.Application.Services;
using SoftClub.Domain.Entities;
using SoftClub.Infrastructure.Extensions;
using SoftClub.Persistence.DataContexts;
using SoftClub.Persistence.Repository;

namespace SoftClub.Infrastructure.Services;

public class CarService(IRepository<Car, ApplicationDbContext> repository) : ICarService
{
    public Task<List<Car>> GetAsync(CarFilter filter, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = repository.Get();

        if (filter.MinPrice is not null)
            query = query.Where(entity => entity.Price > filter.MinPrice);

        if (filter.MaxPrice is not null)
            query = query.Where(entity => entity.Price < filter.MaxPrice);

        if (filter.MinYear is not null)
            query = query.Where(entity => entity.Price > filter.MinYear);

        if (filter.MaxYear is not null)
            query = query.Where(entity => entity.Price < filter.MaxYear);

        if (filter.FuelType is not null)
            query = query.Where(entity => entity.FuelType.ToLower().Contains(filter.FuelType.ToLower()));

        if (filter.Transmission is not null)
            query = query.Where(entity => entity.Transmission.ToLower().Contains(filter.Transmission.ToLower()));

        if (filter.BrandId is not null)
            query = query.Where(entity => entity.BrandId == filter.BrandId);

        if (filter.DealerId is not null)
            query = query.Where(entity => entity.DealerId == filter.DealerId);

        if (filter.IsAvailable is not null)
            query = query.Where(entity => entity.IsAvailable == filter.IsAvailable);

        if (filter.CityId is not null)
            query.Where(entity => entity.Dealer.CityId == filter.CityId);

        //query = query
            //.Include(entity => entity.Brand)
            //.Include(entity => entity.Dealer);

        return query.ToPaginateAsync(filter, cancellationToken);
    }

    public async Task<Car> GetByIdAsync(int id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var car = await repository.GetByIdAsync(id, asNoTracking, cancellationToken)
            ?? throw new InvalidOperationException($"Car does not exist with ID {id}");

        return car;
    }

    public async Task<Car> CreateAsync(Car car, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var entity = await repository.CreateAsync(car, saveChanges, cancellationToken);

        return entity;
    }

    public async Task<Car> UpdateAsync(int id, Car car, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var exist = await GetByIdAsync(id, cancellationToken: cancellationToken);

        exist.Year = car.Year;
        exist.Model = car.Model;
        exist.BrandId = car.BrandId;
        exist.Price = car.Price;
        exist.Mileage = car.Mileage;
        exist.Color = car.Color;
        exist.FuelType = car.FuelType;
        exist.Transmission = car.Transmission;
        exist.DealerId = car.DealerId;
        exist.IsAvailable = car.IsAvailable;
        exist.Description = car.Description;
        exist.ImageUrl = car.ImageUrl;

        if (saveChanges)
            await repository.SaveChangesAsync(cancellationToken);

        return exist;
    }

    public async Task<bool> DeleteByIdAsync(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var exist = await GetByIdAsync(id, cancellationToken: cancellationToken);

        await repository.DeleteAsync(exist);

        return exist is not null ? true : false;
    }
}