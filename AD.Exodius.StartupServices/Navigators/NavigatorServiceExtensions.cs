using AD.Exodius.Navigators.Factories;
using AD.Exodius.Navigators.Strategies.Factories;
using AD.Exodius.Pages.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace AD.Exodius.StartupServices.Navigators;

public static class NavigatorServiceExtensions
{
    public static IServiceCollection AddNavigatorServices(this IServiceCollection services)
    {
        services
            .AddScoped<IPageObjectFactory, PageObjectFactory>()
            .AddScoped<INavigationStrategyFactory, NavigationStrategyFactory>()
            .AddScoped<INavigatorFactory, NavigatorFactory>();

        return services;
    }
}
