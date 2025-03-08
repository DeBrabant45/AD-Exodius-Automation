using AD.Exodius.Components;
using AD.Exodius.Locators;
using AD.Exodius.Pages;

namespace Mock.SwagLabs.Components;

public class NavigationActionComponent(IDriver driver, IPageObject owner) 
    : PageComponent(driver, owner), INavigationActionComponent
{
    private ButtonElement BurgerMenuButton => Driver.FindElement<ById, ButtonElement>("react-burger-menu-btn");
    private LabelElement MenuWrapLabel => Driver.FindElement<ByXPath, LabelElement>("//div[@class='bm-menu-wrap']");

    public async Task ClickAction(string item)
    {
        if (await MenuWrapLabel.IsAttributePresent("aria-hidden", "false"))
            return;

        await BurgerMenuButton.Click();
    }
}
