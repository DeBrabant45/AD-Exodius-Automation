using Microsoft.Extensions.DependencyInjection;

namespace Mock.SwagLabs.Tests;

public static class ServiceCollectionProvider
{
    private static readonly ServiceCollection _services = new();

    static ServiceCollectionProvider()
    {
        var startupType = GetStartupType();
        InvokeConfigureServices(startupType);
        _services.BuildServiceProvider();
    }

    public static IServiceProvider ServiceProvider => _services.BuildServiceProvider();

    private static Type GetStartupType()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            var startupType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == "Startup" && t.IsClass);

            if (startupType != null)
            {
                return startupType;
            }
        }

        throw new InvalidOperationException("No Startup class found in the project.");
    }

    private static void InvokeConfigureServices(Type startupType)
    {
        var startupInstance = Activator.CreateInstance(startupType);

        var configureServicesMethod = startupType.GetMethod("ConfigureServices") 
            ?? throw new InvalidOperationException("ConfigureServices method not found on Startup class.");

        configureServicesMethod.Invoke(startupInstance, [_services]);
    }
}
