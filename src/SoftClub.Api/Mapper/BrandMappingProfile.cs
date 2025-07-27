using AutoMapper;
using SoftClub.Application.Dtos;
using SoftClub.Domain.Entities;

namespace SoftClub.Api.Mapper;

public class BrandMappingProfile : Profile
{
    public BrandMappingProfile()
    {
        CreateMap<BrandDto, Brand>();
    }
}