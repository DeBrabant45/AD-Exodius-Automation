﻿using Mock.SwagLabs.Models;
using Mock.SwagLabs.Sections.Navigationbar;

namespace Mock.SwagLabs.Pages;

public class LoginPage : BasePage
{
    public LoginPage(IDriver driver, NavigationbarSection navigationbar) 
        : base(driver, navigationbar)
    {

    }

    private TextInputElement UserNameTextbox => Driver.FindElementById<TextInputElement>("user-name");
    private TextInputElement PasswordTextbox => Driver.FindElementById<TextInputElement>("password");
    private ButtonElement LoginButton => Driver.FindElementById<ButtonElement>("login-button");
    private TextInputElement ErrorMessage => Driver.FindElementByTestData<TextInputElement>("error");

    public async Task LoginToSwagLabs(Login login)
    {
        await UserNameTextbox.TypeInput(login.Username);
        await PasswordTextbox.TypeInput(login.Password);
        await LoginButton.Click();
    }

    public async Task<bool> IsErrorMessagePresent() => await ErrorMessage.IsVisible() ?? false;

    public async Task<string> ErrorMessageText() => await ErrorMessage.Text();
}
