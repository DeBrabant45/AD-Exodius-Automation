using Mock.SwagLabs.Models;
using Mock.SwagLabs.Pages;
using Mock.SwagLabs.Tests.Fixture;
using AD.Playwrightlib.Configuration;
using AD.Playwrightlib.Driver;

namespace Mock.SwagLabs.Tests.LoginTests;

public class LoginTests : BaseTestFixture
{
    private readonly LoginPage _loginPage;

    public LoginTests(ITestOutputHelper output, IDriver driver, TestSettings settings, 
        LoginPage loginPage) 
        : base(output, driver, settings)
    {
        Driver.GoToUrl(settings.ApplicationUrl);
        _loginPage = loginPage;
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce")]
    [InlineData("performance_glitch_user", "secret_sauce")]
    [InlineData("problem_user", "secret_sauce")]
    public async Task User_Should_Login_Without_Errors(string username, string password)
    {
        var login = new Login { Username = username, Password = password };
        await _loginPage.LoginToSwagLabs(login);
        var actualResult = await _loginPage.IsErrorMessagePresent();
        Assert.False(actualResult);
    }

    [Theory, AutoData]
    public async Task User_Should_See_Login_Error_Message(Login login)
    {
        await _loginPage.LoginToSwagLabs(login);
        var actualResult = await _loginPage.ErrorMessageText();
        var expectedResult = "Epic sadface: Username and password do not match any user in this service";
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("locked_out_user", "secret_sauce")]
    public async Task User_Should_See_Login_Locked_Out_Error_Message(string username, string password)
    {
        var login = new Login { Username = username, Password = password };
        await _loginPage.LoginToSwagLabs(login);
        var actualResult = await _loginPage.ErrorMessageText();
        var expectedResult = "Epic sadface: Sorry, this user has been locked out.";
        Assert.Equal(expectedResult, actualResult);
    }
}
