using AD.Exodius.Components;
using Microsoft.Extensions.DependencyInjection;
using Mock.SwagLabs.Components.Sections;

namespace Mock.SwagLabs.StartupServices;

public static class PageComponentServiceExtensions
{
    public static IServiceCollection AddPageComponentServices(this IServiceCollection services)
    {
        services
            .AddScoped<IWaitSection, WaitSection>()
            .AddScoped<IProductSortSection, ProductSortSection>()
            .AddScoped<IInventorySection, InventorySection>();

        return services;
    }
}
