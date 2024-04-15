using Microsoft.EntityFrameworkCore;
using PlatformService.Data.Interfaces;
using PlatformService.Models;

namespace PlatformService.Data.Implementations;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public bool Save()
    {
        return _context.SaveChanges() >= 0;
    }

    public IEnumerable<Platform> GetAll()
    {
        return _context.Platforms.ToList();
    }

    public Platform? GetById(Guid id)
    {
        return _context.Platforms.FirstOrDefault(p => p.Id == id);
    }

    public void Create(Platform platform)
    {
        ArgumentNullException.ThrowIfNull(platform);

        _context.Platforms.Add(platform);
    }
}