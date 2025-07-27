using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SoftClub.Application.Dtos;
using SoftClub.Application.Filters;
using SoftClub.Application.Services;
using SoftClub.Domain.Common.Pagination;
using SoftClub.Domain.Entities;

namespace SoftClub.Api.Controllers;

public class CitiesController(ICityService service, IMapper mapper) : BaseController
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAll([FromQuery] Pagination filter, CancellationToken cancellationToken)
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
    public async ValueTask<IActionResult> Post([FromBody] CityDto dto, CancellationToken cancellationToken)
    {
        var data = await service.CreateAsync(mapper.Map<City>(dto), cancellationToken: cancellationToken);

        return Ok(data);
    }

    [HttpPut("{id:int}")]
    public async ValueTask<IActionResult> Put([FromRoute] int id, [FromBody] CityDto dto, CancellationToken cancellationToken)
    {
        var data = await service.UpdateAsync(id, mapper.Map<City>(dto), cancellationToken: cancellationToken);

        return Ok(data);
    }

    [HttpDelete("{id:int}")]
    public async ValueTask<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        var data = await service.DeleteByIdAsync(id, cancellationToken: cancellationToken);

        return Ok(data);
    }
}