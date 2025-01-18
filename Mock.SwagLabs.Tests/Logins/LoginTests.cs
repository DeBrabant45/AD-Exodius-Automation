using AD.Exodius.Drivers;
using AD.Exodius.Navigators;
using AD.Exodius.Navigators.Strategies;
using AD.Exodius.Utility.Tasks;
using Mock.SwagLabs.Configurations.Models;
using Mock.SwagLabs.Pages;
using Mock.SwagLabs.Pages.Models;
using Mock.SwagLabs.Tests.Fixtures;

namespace Mock.SwagLabs.Tests.Logins;

public class LoginTests : BaseTestFixture
{
    private readonly INavigator _navigator;

    public LoginTests(
        ITestOutputHelper output,
        IDriver driver,
        TestSettings settings,
        INavigator navigator)
        : base(output, driver, settings)
    {
        _navigator = navigator;
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce")]
    [InlineData("performance_glitch_user", "secret_sauce")]
    [InlineData("problem_user", "secret_sauce")]
    public async Task User_Should_Login_Without_Errors(string username, string password)
    {
        var login = new Login { Username = username, Password = password };

        var isLoginPageErrorMessagePresent = await _navigator
            .GoTo<LoginPage, ByRoute>()
            .Then(page => page.Login(login))
            .Then(page => page.IsErrorMessagePresent());

        isLoginPageErrorMessagePresent
            .Should()
            .BeFalse();
    }

    [Theory, AutoData]
    public async Task User_Should_See_Login_Error_Message(Login login)
    {
        var loginPageErrorMessage = await _navigator
            .GoTo<LoginPage, ByRoute>()
            .Then(page => page.Login(login))
            .Then(page => page.GetErrorMessageText());

        loginPageErrorMessage.Should().Be("Epic sadface: Username and password do not match any user in this service");
    }

    [Theory]
    [InlineData("locked_out_user", "secret_sauce")]
    public async Task User_Should_See_Login_Locked_Out_Error_Message(string username, string password)
    {
        var login = new Login { Username = username, Password = password };

        var loginPageErrorMessage = await _navigator
            .GoTo<LoginPage, ByRoute>()
            .Then(page => page.Login(login))
            .Then(page => page.GetErrorMessageText());

        loginPageErrorMessage
            .Should()
            .Be("Epic sadface: Sorry, this user has been locked out.");
    }
}
