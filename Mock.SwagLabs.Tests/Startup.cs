using Microsoft.Extensions.DependencyInjection;
using Mock.SwagLabs.Pages;
using Mock.SwagLabs.Sections.Navigationbar;
using PlaywrightLibrary.Configuration;
using PlaywrightLibrary.Driver;

namespace Mock.SwagLabs.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton(ConfigurationReader.Read())
            .AddScoped<IBrowserFactory, BrowserFactory>()
            .AddScoped<IElementFactory, ElementFactory>()
            .AddScoped<IDriver, PageDriver>()
            .AddScoped<NavigationbarSection>()
            .AddScoped<LoginPage>();
    }
}
