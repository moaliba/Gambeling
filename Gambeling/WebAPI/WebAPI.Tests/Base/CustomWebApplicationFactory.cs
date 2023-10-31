using Gambeling.DataAccessContext.Context;
using Gambeling.WebAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace WebAPI.Tests.Base;

public class CustomWebApplicationFactory : BaseWebApplicationFactory<Startup>
{
    public CustomWebApplicationFactory()
    {
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();


        builder.ConfigureServices(services =>
        {
            services.AddScoped(sp =>
            {
                return new DbContextOptionsBuilder<GambelingDbContext>()
               .UseInMemoryDatabase("GambelingDB", root)
               .UseApplicationServiceProvider(sp)
               .Options;

            });
        });
        builder.UseContentRoot(Directory.GetCurrentDirectory());
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}
