namespace Mock.SwagLabs.Sections.Navigationbar;

public class NavigationbarSection : BaseSection
{
    public NavigationbarSection(IDriver driver) : base(driver)
    {

    }

    private ButtonElement BurgerMenuButton => Driver.FindElementById<ButtonElement>("react-burger-menu-btn");
    private AchorElement AllItemsAchor => Driver.FindElementById<AchorElement>("inventory_sidebar_link");
    private AchorElement AboutAchor => Driver.FindElementById<AchorElement>("about_sidebar_link");
    private AchorElement LogoutAchor => Driver.FindElementById<AchorElement>("logout_sidebar_link");
    private AchorElement ResetAppStateAchor => Driver.FindElementById<AchorElement>("reset_sidebar_link");
    private AchorElement ShoppingCartAchor => Driver.FindElementById<AchorElement>("shopping_cart_container");

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
