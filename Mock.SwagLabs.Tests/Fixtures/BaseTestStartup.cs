using AD.Exodius.Configurations;
using AD.Exodius.Drivers;
using AD.Exodius.Drivers.Factories;
using AD.Exodius.Navigators;
using AD.Exodius.Navigators.Factories;
using Mock.SwagLabs.Configurations;
using Mock.SwagLabs.Configurations.Models;
using Mock.SwagLabs.Tests.Services;
using NUnit.Framework;

[assembly: LevelOfParallelism(4)]

namespace Mock.SwagLabs.Tests.Fixtures;

public abstract class BaseTestStartup
{
    protected IDriver Driver { get; private set; } = null!;
    protected INavigator Navigator { get; private set; } = null!;
    protected DriverSettings DriverSettings { get; private set; }
    protected ApplicationSettings ApplicationSettings { get; private set; }
    protected static ReportingService ReportingService { get; set; } = null!;
    protected IServiceProvider ServiceProvider => ServiceCollectionProvider.ServiceProvider;

    protected BaseTestStartup()
    {
        DriverSettings = DriverConfigurationReader.Read();
        ApplicationSettings = AppsettingConfigurationReader.Read();
    }

    [OneTimeSetUp]
    public static void GlobalSetup()
    {
        ReportingService = new ReportingService("test-results.html");
    }

    [SetUp]
    public async Task SetUp()
    {
        Driver = new DriverFactory().Create(DriverSettings);
        Navigator = new NavigatorFactory().Create<Navigator>(Driver);
        ReportingService.CreateTest(TestContext.CurrentContext);

        await SetUpInternal();
    }

    protected virtual async Task SetUpInternal()
    {
        await Driver.OpenPage();
        await Driver.GoToUrl(ApplicationSettings.BaseUrl);
    }

    [TearDown]
    public async Task TearDown()
    {
        ReportingService.LogTestResult(TestContext.CurrentContext);
        await TearDownInternal();
    }

    protected virtual async Task TearDownInternal()
    {
        await Driver.ClosePage();
        Driver.Dispose();
    }

    [OneTimeTearDown]
    public static void GlobalTeardown()
    {
        ReportingService.FlushReports();
    }
}
