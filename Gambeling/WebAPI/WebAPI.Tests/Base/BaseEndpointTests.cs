using Gambeling.WebAPI;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace WebAPI.Tests.Base;

public abstract class BaseEndpointTests
{
    protected BaseWebApplicationFactory<Startup> Factory { get; }

    protected BaseEndpointTests(BaseWebApplicationFactory<Startup> factory)
    => Factory = factory;

}
