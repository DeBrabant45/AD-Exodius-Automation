using Microsoft.Extensions.DependencyInjection;
using AD.Exodius.Configurations;
using AD.Exodius.Drivers.Factories;

namespace AD.Exodius.StartupServices.Drivers;

public static class DriverServiceExtensions
{
    public static IServiceCollection AddDriverServices(this IServiceCollection services)
    {
        services.AddSingleton(DriverConfigurationReader.Read());
        services.AddDriverFactory();

        return services;
    }

    private static IServiceCollection AddDriverFactory(this IServiceCollection services)
    {
        services
            .AddScoped<IDriverFactory, DriverFactory>()
            .AddScoped(serviceProvider =>
            {
                var driverFactory = serviceProvider.GetRequiredService<IDriverFactory>();
                var driverSettings = serviceProvider.GetRequiredService<DriverSettings>();
                return driverFactory.Create(driverSettings);
            });

        return services;
    }
}
