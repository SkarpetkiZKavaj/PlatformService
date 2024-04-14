using AutoMapper;
using PlatformService.Data.Dtos;
using PlatformService.Models;

namespace PlatformService.Mapping.Profiles;

public class PlatformsProfile : Profile 
{
    public PlatformsProfile()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<PlatformCreateDto, Platform>();
    }
}