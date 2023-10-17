using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebAPI.Tests.Base;

public abstract class BaseWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    protected override IWebHostBuilder CreateWebHostBuilder()
    => WebHost.CreateDefaultBuilder().UseStartup<TStartup>();

}
