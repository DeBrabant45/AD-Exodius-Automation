using AD.Exodius.Configurations;
using AD.Exodius.Drivers;
using Mock.SwagLabs.Configurations.Models;
using Xunit.Abstractions;

namespace Mock.SwagLabs.Tests.Fixtures;

public class BaseTestFixture : IAsyncLifetime
{
    protected readonly IDriver Driver;
    protected readonly TestSettings Settings;
    protected readonly ITestOutputHelper Output;
    protected readonly ApplicationSettings ApplicationSettings;
    protected readonly DriverSettings DriverSettings;

    public BaseTestFixture(
        ITestOutputHelper output, 
        IDriver driver, 
        TestSettings settings)
    {
        Output = output;
        Driver = driver;
        Settings = settings;
        ApplicationSettings = settings.ApplicationSettings;
        DriverSettings = settings.DriverSettings;
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
