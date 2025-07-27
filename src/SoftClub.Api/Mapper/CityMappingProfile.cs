using AutoMapper;
using SoftClub.Application.Dtos;
using SoftClub.Domain.Entities;

namespace SoftClub.Api.Mapper;

public class CityMappingProfile : Profile
{
    public CityMappingProfile()
    {
        CreateMap<CityDto, City>();
    }
}