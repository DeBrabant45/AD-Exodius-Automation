using Microsoft.Extensions.DependencyInjection;
using AD.Exodius.Components;
using AD.Exodius.Components.Factories;
using AD.Exodius.StartupServices.Extensions;

namespace AD.Exodius.StartupServices.Components;

public static class PageComponentServiceExtensions
{
    public static IServiceCollection AddPageComponentFactoryServices(this IServiceCollection services)
    {
        services.AddScoped<IPageComponentFactory>(serviceProvider =>
        {
            var pageComponents = services.GetServicesOfType<IPageComponent>(serviceProvider).ToList();

            return new PageComponentFactory(pageComponents);
        });

        return services;
    }
}
