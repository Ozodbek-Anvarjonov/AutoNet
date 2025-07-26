using AutoMapper;
using SoftClub.Application.Dtos;
using SoftClub.Domain.Entities;

namespace SoftClub.Api.Mapper;

public class CarMappingProfile : Profile
{
    public CarMappingProfile()
    {
        CreateMap<CarDto, Car>();
    }
}