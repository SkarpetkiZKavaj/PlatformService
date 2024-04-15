using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Dtos;
using PlatformService.Data.Interfaces;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepository _repository;
    private readonly IMapper _mapper;
    
    public PlatformsController(IPlatformRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        var platforms = _repository.GetAll();

        return Ok(_mapper.Map<IEnumerable<Platform>, IEnumerable<PlatformReadDto>>(platforms));
    }

    [HttpGet("{id:guid}", Name = "GetPlatform")]
    public ActionResult<PlatformReadDto> GetPlatform(Guid id)
    {
        var platform = _repository.GetById(id);

        if (platform is null)
        {
            return NotFound($"Platform with id {id} was not found");
        }

        return Ok(_mapper.Map<Platform, PlatformReadDto>(platform));
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platform)
    {
        var platformModel = _mapper.Map<PlatformCreateDto, Platform>(platform);
        
        _repository.Create(platformModel);
        _repository.Save();

        var platformReadDto = _mapper.Map<Platform, PlatformReadDto>(platformModel);
        
        return CreatedAtRoute(nameof(GetPlatform), new { Id = platformReadDto.Id }, platformReadDto);
    }
}