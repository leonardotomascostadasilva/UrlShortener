using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
namespace UrlShortner.App.IntegrationTests.Configuration;
public class ApplicationBuilder : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        return base.CreateHost(builder);
    }
}
