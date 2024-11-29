using AD.Exodius.StartupServices.Components;
using AD.Exodius.StartupServices.Drivers;
using AD.Exodius.StartupServices.Navigators;
using Microsoft.Extensions.DependencyInjection;
using Mock.SwagLabs.StartupServices;

namespace Mock.SwagLabs.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddDriverServices()
            .AddNavigatorServices()
            .AddNavigatorActionServices()
            .AddPageServices()
            .AddPageComponentFactoryServices()
            .AddPageComponentServices()
            .AddApplicationSettingServices();
    }
}
