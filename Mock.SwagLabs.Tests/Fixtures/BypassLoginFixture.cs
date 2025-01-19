using AD.Exodius.Navigators.Strategies;
using AD.Exodius.Utility.Tasks;
using Mock.SwagLabs.Configurations.Models;
using Mock.SwagLabs.Pages;
using Mock.SwagLabs.Pages.Mappers;

namespace Mock.SwagLabs.Tests.Fixtures;

public class BypassLoginFixture : BaseTestFixture
{
    public BypassLoginFixture(ITestOutputHelper output)
        : base(output)
    {

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
