using AD.Exodius.Drivers;
using AD.Exodius.Navigators.Strategies.Factories;
using AD.Exodius.Pages.Factories;

namespace AD.Exodius.Navigators.Factories;

public class NavigatorFactory : INavigatorFactory
{
    private readonly IPageObjectFactory _pageObjectFactory;
    private readonly INavigationStrategyFactory _navigationStrategyFactory;

    public NavigatorFactory(
        IPageObjectFactory pageObjectFactory,
        INavigationStrategyFactory navigationStrategyFactory)
    {
        _pageObjectFactory = pageObjectFactory;
        _navigationStrategyFactory = navigationStrategyFactory;
    }

    public TNavigator Create<TNavigator>(IDriver driver) where TNavigator : INavigator
    {
        ArgumentNullException.ThrowIfNull(driver);

        var instance = Activator.CreateInstance(typeof(TNavigator), 
            driver, 
            _pageObjectFactory, 
            _navigationStrategyFactory)
            ?? throw new InvalidOperationException($"Failed to create an instance of {typeof(TNavigator).Name}.");

        return (TNavigator)instance;
    }
}
