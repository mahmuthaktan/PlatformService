using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformService.Data 
{
    public static   class PrepDb 
    {
        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                context.Platforms.AddRange(
                    new Platform { Name = "Windows" },
                    new Platform { Name = "Linux" },
                    new Platform { Name = "MacOS" }
                );
                context.SaveChanges();
            }
        }
public static void PrepPopulation(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
      SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());  
    }
}
    }
}
  