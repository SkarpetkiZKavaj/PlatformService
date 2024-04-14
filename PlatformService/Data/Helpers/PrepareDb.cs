using PlatformService.Models;

namespace PlatformService.Data.Helpers;

public static class PrepareDb
{
    public static void PreparePopulation(IApplicationBuilder builder)
    {
        using (var serviceScope = builder.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());                
        }
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            context.Platforms.AddRange(
                new Platform() { Name = "Dotnet", Publisher = "Microsoft", Cost = "Free" },
                           new Platform() { Name = "Microsoft SQL server", Publisher = "Microsoft", Cost = "Free" });

            context.SaveChanges();
        }
    }
}