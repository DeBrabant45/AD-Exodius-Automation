using Microsoft.Extensions.DependencyInjection;
using Mock.SwagLabs.Pages;
using Mock.SwagLabs.Sections.Navigationbar;
using AD.Exodius.Configuration;
using AD.Exodius.Driver;
using Xunit.DependencyInjection;

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
            .AddScoped<InventoryPage>()
            .AddScoped<LoginPage>();
    }
}
