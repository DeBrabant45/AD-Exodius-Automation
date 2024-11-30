using AD.Exodius.Driver;
using AD.Exodius.Navigators;
using AD.Exodius.Navigators.Strategies;
using AD.Exodius.Utility.Tasks;
using Mock.SwagLabs.Configurations.Models;
using Mock.SwagLabs.Pages;
using Mock.SwagLabs.Pages.Mappers;
using Xunit.Abstractions;

namespace Mock.SwagLabs.Tests.Fixtures;

public class BypassLoginFixture : BaseTestFixture
{
    protected INavigator Navigator;

    public BypassLoginFixture(
        ITestOutputHelper output, 
        IDriver driver, 
        TestSettings settings,
        INavigator navigator) 
        : base(output, driver, settings)
    {
        Navigator = navigator;
    }

    protected override async Task Setup()
    {
        await base.Setup();

        var login = ApplicationSettings
            .GetFirstUser()
            .ToLogin();

        await Navigator
            .GoTo<LoginPage, ByRoute>()
            .Then(page => page.Login(login));
    }
}
