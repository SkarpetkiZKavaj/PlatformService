using Microsoft.EntityFrameworkCore;
using PlatformService.Data.Interfaces;
using PlatformService.Models;

namespace PlatformService.Data.Implementations;

public class PlatformRepository(AppDbContext context) : IPlatformRepository
{
    private readonly DbSet<Platform> _platforms = context.Platforms;
    
    public bool Save()
    {
        return context.SaveChanges() >= 0;
    }

    public IEnumerable<Platform> GetAll()
    {
        return _platforms.ToList();
    }

    public Platform GetById(Guid id)
    {
        return _platforms.FirstOrDefault(p => p.Id == id);
    }

    public void Create(Platform platform)
    {
        ArgumentNullException.ThrowIfNull(platform);

        _platforms.Add(platform);
    }
}