using AD.Exodius.Drivers;
using AD.Exodius.Navigators.Strategies.Factories;
using AD.Exodius.Pages.Factories;

namespace AD.Exodius.Navigators.Factories;

public class NavigatorFactory : INavigatorFactory
{
    private readonly IPageObjectFactory _pageObjectFactory;
    private readonly IPageObjectRegistryFactory _pageObjectRegistryFactory;
    private readonly INavigationStrategyFactory _navigationStrategyFactory;

    public NavigatorFactory(
        IPageObjectFactory? pageObjectFactory = null,
        IPageObjectRegistryFactory? pageObjectRegistryFactory = null,
        INavigationStrategyFactory? navigationStrategyFactory = null)
    {
        _pageObjectFactory = pageObjectFactory ?? new PageObjectFactory();
        _pageObjectRegistryFactory = pageObjectRegistryFactory ?? new PageObjectRegistryFactory();
        _navigationStrategyFactory = navigationStrategyFactory ?? new NavigationStrategyFactory();
    }

    public TNavigator Create<TNavigator>(IDriver driver) where TNavigator : INavigator
    {
        ArgumentNullException.ThrowIfNull(driver);

        var instance = Activator.CreateInstance(typeof(TNavigator), 
            driver, 
            _pageObjectFactory,
            _pageObjectRegistryFactory,
            _navigationStrategyFactory)
            ?? throw new InvalidOperationException($"Failed to create an instance of {typeof(TNavigator).Name}.");

        return (TNavigator)instance;
    }
}
