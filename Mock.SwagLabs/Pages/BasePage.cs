using Mock.SwagLabs.Sections.Navigationbar;

namespace Mock.SwagLabs.Pages;

public abstract class BasePage 
{
    protected IDriver Driver;
    protected NavigationbarSection Navigationbar;

    protected BasePage(IDriver driver, NavigationbarSection navigationbar)
    {
        Driver = driver;
        Navigationbar = navigationbar;
    }
}