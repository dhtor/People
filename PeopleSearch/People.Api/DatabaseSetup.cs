using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using People.DataLayer.Context;
using System;

namespace People.Api
{
    public static class DatabaseSetup
    {
        public static IWebHost SetupDevelopmentDatabase(this IWebHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                using (var context = services.GetRequiredService<ApplicationDbContext>())
                {
                    try
                    {
                        context.EnsureCreated();
                        context.SeedDatabase();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Problem seeding data - This needs to be logged - Not in the scope");
                    }
                }
            }

            return webHost;
        }
    }
}
