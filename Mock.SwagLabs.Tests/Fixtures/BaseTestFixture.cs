using AD.Exodius.Driver;
using Mock.SwagLabs.Configurations.Models;
using Xunit.Abstractions;

namespace Mock.SwagLabs.Tests.Fixtures;

public class BaseTestFixture : IAsyncLifetime
{
    protected readonly IDriver Driver;
    protected readonly TestSettings Settings;
    protected readonly ITestOutputHelper Output;
    protected readonly ApplicationSettings ApplicationSettings;

    public BaseTestFixture(
        ITestOutputHelper output, 
        IDriver driver, 
        TestSettings settings)
    {
        Output = output;
        Driver = driver;
        Settings = settings;
        ApplicationSettings = settings.ApplicationSettings;
    }

    public async Task InitializeAsync()
    {
        await Driver.OpenPage();
        await Driver.GoToUrl(ApplicationSettings.BaseUrl);
    }

    public async Task DisposeAsync()
    {
        await Driver.ClosePage();   
    }
}
