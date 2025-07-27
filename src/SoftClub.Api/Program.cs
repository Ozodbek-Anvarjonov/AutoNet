using Microsoft.EntityFrameworkCore;
using SoftClub.Api.ExceptionHandlers;
using SoftClub.Application.Services;
using SoftClub.Domain.Entities;
using SoftClub.Infrastructure.Services;
using SoftClub.Persistence.DataContexts;
using SoftClub.Persistence.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IDealerService, DealerService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddDbContext<DbContext, ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDbConnection"));
});
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped<IRepository<Car, ApplicationDbContext>, Repository<Car, ApplicationDbContext>>();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<InvalidOperationExceptionHandler>();
builder.Services.AddExceptionHandler<InternalServerExceptionHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler();

app.MapControllers();

app.Run();
