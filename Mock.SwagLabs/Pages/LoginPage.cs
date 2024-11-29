using AD.Exodius.Locators;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Attributes;
using Mock.SwagLabs.Pages.Models;

namespace Mock.SwagLabs.Pages;

[PageObjectRoute("/")]
public class LoginPage : PageObject
{
    public LoginPage(IDriver driver) 
        : base(driver)
    {

    }

    private TextInputElement UserNameTextbox => Driver.FindElement<ById,TextInputElement>("user-name");
    private TextInputElement PasswordTextbox => Driver.FindElement<ById, TextInputElement>("password");
    private ButtonElement LoginButton => Driver.FindElement<ById, ButtonElement>("login-button");
    private LabelElement ErrorMessage => Driver.FindElement<ByTestData, LabelElement>("error");

    public async Task<LoginPage> Login(Login login)
    {
        await UserNameTextbox.TypeInput(login.Username);
        await PasswordTextbox.TypeInput(login.Password);
        await LoginButton.Click();

        return this;
    }

    public async Task<bool> IsErrorMessagePresent() => await ErrorMessage.IsVisible();

    public async Task<string> GetErrorMessageText() => await ErrorMessage.GetText();
}
