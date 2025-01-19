using AD.Exodius.Drivers;

namespace AD.Exodius.Pages.Factories;

public class PageObjectFactory : IPageObjectFactory
{
    public TPage Create<TPage>(IDriver driver) where TPage : IPageObject
    {
        ArgumentNullException.ThrowIfNull(driver);

        var instance = Activator.CreateInstance(typeof(TPage), driver)
            ?? throw new InvalidOperationException($"No page of type {typeof(TPage).Name} found.");

        return (TPage)instance;
    }
}
