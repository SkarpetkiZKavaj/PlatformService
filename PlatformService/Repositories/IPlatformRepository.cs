using PlatformService.Models;

namespace PlatformService.Data.Interfaces;

public interface IPlatformRepository
{
    bool Save();
    IEnumerable<Platform> GetAll();
    Platform? GetById(Guid id);
    void Create(Platform platform);
}