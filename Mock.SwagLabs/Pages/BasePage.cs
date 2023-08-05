using Mock.SwagLabs.Sections.Navigationbar;

namespace Mock.SwagLabs.Pages;

public abstract class BasePage 
{
    protected IDriver Driver;

    protected BasePage(IDriver driver)
    {
        Driver = driver;
    }
}