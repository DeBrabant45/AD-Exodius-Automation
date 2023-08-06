using Mock.SwagLabs.Models;

namespace Mock.SwagLabs.Pages;

public class LoginPage : BasePage
{
    public LoginPage(IDriver driver) 
        : base(driver)
    {

    }

    private TextInputElement UserNameTextbox => Driver.FindElementById<TextInputElement>("user-name");
    private TextInputElement PasswordTextbox => Driver.FindElementById<TextInputElement>("password");
    private ButtonElement LoginButton => Driver.FindElementById<ButtonElement>("login-button");
    private LabelElement ErrorMessage => Driver.FindElementByTestData<LabelElement>("error");

    public async Task LoginToSwagLabs(Login login)
    {
        await UserNameTextbox.TypeInput(login.Username);
        await PasswordTextbox.TypeInput(login.Password);
        await LoginButton.Click();
    }

    public async Task<bool> IsErrorMessagePresent() => await ErrorMessage.IsVisible();

    public async Task<string> ErrorMessageText() => await ErrorMessage.Text();
}
