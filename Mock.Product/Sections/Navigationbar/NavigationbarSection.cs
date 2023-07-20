using PlaywrightLibrary.Elements;

namespace Mock.Product.Sections.Navigationbar;

public class NavigationbarSection : BaseSection
{
    public NavigationbarSection(IDriver driver) 
        : base(driver)
    {
    }

    private ButtonElement HomeButton => Driver.FindElementByXPath<ButtonElement>("(//a[normalize-space()='Home'])[1]");
    private ButtonElement PrivacyButton => Driver.FindElementByXPath<ButtonElement>("//a[@class='nav-link text-dark'][normalize-space()='Privacy']");
    private ButtonElement ProductButton => Driver.FindElementByXPath<ButtonElement>("//a[normalize-space()='Product']");

    public async Task ClickHomeButton() => await HomeButton.Click();

    public async Task ClickPrivacyButton() => await PrivacyButton.Click();

    public async Task ClickProductButton() => await ProductButton.Click();
}