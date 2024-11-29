using AD.Exodius.Navigators.Actions;
using AD.Exodius.Navigators.Factories;
using Microsoft.Extensions.DependencyInjection;
using Mock.SwagLabs.Navigators.Actions;
using Mock.SwagLabs.Navigators.Factories;

namespace Mock.SwagLabs.StartupServices;

public static class NavigatorActionServiceExtensions
{
    public static IServiceCollection AddNavigatorActionServices(this IServiceCollection services)
    {
        services
            .AddScoped<INavigatorActionFactory, NavigatorActionFactory>()
            .AddScoped<INavigatorAction, NavigatorAction>();

        return services;
    }
}
