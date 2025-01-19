using AD.Exodius.Components;
using AD.Exodius.Locators;
using AD.Exodius.Pages;

namespace Mock.SwagLabs.Components.Sections;

public class NavigationActionComponent : PageComponent, INavigationActionComponent
{
    public NavigationActionComponent(
        IDriver driver,
        IPageObject owner)
        : base(driver, owner)
    {

    }

    private ButtonElement BurgerMenuButton => Driver.FindElement<ById, ButtonElement>("react-burger-menu-btn");
    private LabelElement MenuWrapLabel => Driver.FindElement<ByXPath, LabelElement>("//div[@class='bm-menu-wrap']");

    public async Task ClickAction(string item)
    {
        if (await MenuWrapLabel.IsAttributePresent("aria-hidden", "false"))
            return;

        await BurgerMenuButton.Click();
    }
}
