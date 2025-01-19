using AD.Exodius.Configurations;
using AD.Exodius.Drivers;
using AD.Exodius.Navigators;
using AD.Exodius.Navigators.Factories;
using Microsoft.Extensions.DependencyInjection;
using Mock.SwagLabs.Configurations.Models;

namespace Mock.SwagLabs.Tests.Fixtures;

public class BaseTestFixture : IAsyncLifetime
{
    protected readonly IDriver Driver;
    protected readonly INavigator Navigator;
    protected readonly TestSettings Settings;
    protected readonly ITestOutputHelper Output;
    protected readonly DriverSettings DriverSettings;
    protected readonly IServiceProvider ServiceProvider;
    protected readonly ApplicationSettings ApplicationSettings;

    public BaseTestFixture(ITestOutputHelper output)
    {
        Output = output;
        ServiceProvider = ServiceCollectionProvider.ServiceProvider;
        Settings = ServiceProvider.GetRequiredService<TestSettings>();
        Driver = ServiceProvider.GetRequiredService<IDriver>();
        ApplicationSettings = Settings.ApplicationSettings;
        DriverSettings = Settings.DriverSettings;

        Navigator = ServiceProvider
            .GetRequiredService<INavigatorFactory>()
            .Create<Navigator>(Driver);
    }

    public async Task InitializeAsync()
    {
        await Setup();
    }

    protected virtual async Task Setup()
    {
        await Driver.OpenPage();
        await Driver.GoToUrl(ApplicationSettings.BaseUrl);
    }

    public async Task DisposeAsync()
    {
        await TearDown();
    }

    protected virtual async Task TearDown()
    {
        await Driver.ClosePage();
    }
}