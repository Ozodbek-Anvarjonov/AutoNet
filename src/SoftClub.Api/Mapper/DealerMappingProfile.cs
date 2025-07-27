using AutoMapper;
using SoftClub.Application.Dtos;
using SoftClub.Domain.Entities;

namespace SoftClub.Api.Mapper;

public class DealerMappingProfile : Profile
{
    public DealerMappingProfile()
    {
        CreateMap<DealerDto, Dealer>();
    }
}