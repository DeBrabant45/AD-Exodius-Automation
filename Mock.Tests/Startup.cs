using Microsoft.Extensions.DependencyInjection;
using PlaywrightLibrary.Configuration;
using PlaywrightLibrary.Driver;

namespace Mock.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton(ConfigurationReader.Read())
            .AddScoped<IBrowserFactory, BrowserFactory>()
            .AddScoped<IElementFactory, ElementFactory>()
            .AddScoped<IDriver, PageDriver>();
    }
}
