using AD.Exodius.Pages;
using Microsoft.Extensions.DependencyInjection;
using Mock.SwagLabs.Pages;

namespace Mock.SwagLabs.StartupServices;

public static class PageServiceExtensions
{
    public static IServiceCollection AddPageServices(this IServiceCollection service)
    {
        service.AddScoped<IPageObject, LoginPage>();

        return service;
    }
}
