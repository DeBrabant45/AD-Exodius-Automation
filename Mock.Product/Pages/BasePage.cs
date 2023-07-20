using Mock.Product.Sections.Navigationbar;

namespace Mock.Product.Pages;

public abstract class BasePage 
{
    protected IDriver Driver;
    protected NavigationbarSection Navigationbar;

    protected BasePage(IDriver driver)
    {
        Driver = driver;
        Navigationbar = new NavigationbarSection(Driver);
    }
}