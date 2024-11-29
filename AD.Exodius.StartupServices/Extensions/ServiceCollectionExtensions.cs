using Microsoft.Extensions.DependencyInjection;

namespace AD.Exodius.StartupServices.Extensions;

public static class ServiceCollectionExtensions
{
    public static IEnumerable<T> GetServicesOfType<T>(this IServiceCollection services, IServiceProvider serviceProvider)
    {
        var serviceInstances = new List<T>();

        foreach (var descriptor in services)
        {
            if (!typeof(T).IsAssignableFrom(descriptor.ServiceType))
                continue;

            var service = serviceProvider.GetService(descriptor.ServiceType);

            if (service is T typedService)
            {
                serviceInstances.Add(typedService);
            }
        }

        return serviceInstances;
    }
}
