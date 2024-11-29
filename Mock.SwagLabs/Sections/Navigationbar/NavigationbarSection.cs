using AD.Exodius.Locators;

namespace Mock.SwagLabs.Sections.Navigationbar;

public class NavigationbarSection : BaseSection
{
    public NavigationbarSection(IDriver driver) : base(driver)
    {

    }

    private ButtonElement BurgerMenuButton => Driver.FindElement<ById, ButtonElement>("react-burger-menu-btn");
    private AnchorElement AllItemsAchor => Driver.FindElement<ById, AnchorElement>("inventory_sidebar_link");
    private AnchorElement AboutAchor => Driver.FindElement<ById, AnchorElement>("about_sidebar_link");
    private AnchorElement LogoutAchor => Driver.FindElement<ById, AnchorElement>("logout_sidebar_link");
    private AnchorElement ResetAppStateAchor => Driver.FindElement<ById, AnchorElement>("reset_sidebar_link");
    private AnchorElement ShoppingCartAchor => Driver.FindElement<ById, AnchorElement>("shopping_cart_container");

    public async Task GoToAllItems()
    {
        await BurgerMenuButton.Click();
        await AllItemsAchor.Click();
    }

    public async Task GoToAbout()
    {
        await BurgerMenuButton.Click();
        await AboutAchor.Click();
    }

    public async Task GoToLogout()
    {
        await BurgerMenuButton.Click();
        await LogoutAchor.Click();
    }

    public async Task GoToResetAppState()
    {
        await BurgerMenuButton.Click();
        await ResetAppStateAchor.Click();
    }

    public async Task GoToShoppingCart() => await ShoppingCartAchor.Click();

}
