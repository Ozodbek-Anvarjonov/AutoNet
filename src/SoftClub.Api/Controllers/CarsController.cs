using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SoftClub.Application.Dtos;
using SoftClub.Application.Filters;
using SoftClub.Application.Services;
using SoftClub.Domain.Entities;

namespace SoftClub.Api.Controllers;

public class CarsController(ICarService service, IMapper mapper) : BaseController
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAll([FromQuery] CarFilter filter, CancellationToken cancellationToken)
    {
        var data = await service.GetAsync(filter, true, cancellationToken);
        
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async ValueTask<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var data = await service.GetByIdAsync(id, true, cancellationToken);
        
        return Ok(data);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Post([FromBody] CarDto car, CancellationToken cancellationToken)
    {
        var data = await service.CreateAsync(mapper.Map<Car>(car), cancellationToken: cancellationToken);

        return Ok(data);
    }

    [HttpPut("{id:int}")]
    public async ValueTask<IActionResult> Put([FromRoute] int id, [FromBody] CarDto car, CancellationToken cancellationToken)
    {
        var data = await service.UpdateAsync(id, mapper.Map<Car>(car), cancellationToken: cancellationToken);

        return Ok(data);
    }

    [HttpDelete("{id:int}")]
    public async ValueTask<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        var data = await service.DeleteByIdAsync(id, cancellationToken: cancellationToken);

        return Ok(data);
    }
}