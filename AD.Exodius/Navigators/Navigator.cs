using AD.Exodius.Drivers;
using AD.Exodius.Navigators.Strategies;
using AD.Exodius.Navigators.Strategies.Factories;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Factories;

namespace AD.Exodius.Navigators;

public class Navigator : INavigator
{
    private readonly IDriver _driver;
    private readonly IPageObjectFactory _pageObjectFactory;
    private readonly IPageObjectRegistryFactory _pageObjectRegistryFactory;
    private readonly INavigationStrategyFactory _navigationStrategyFactory;

    public Navigator(
        IDriver driver,
        IPageObjectFactory pageObjectFactory,
        IPageObjectRegistryFactory pageObjectRegistryFactory,
        INavigationStrategyFactory navigationStrategyFactory)
    {
        _driver = driver;
        _pageObjectFactory = pageObjectFactory;
        _pageObjectRegistryFactory = pageObjectRegistryFactory;
        _navigationStrategyFactory = navigationStrategyFactory;
    }

    public virtual async Task<TPage> GoTo<TPage, TNavigation>()
        where TPage : IPageObject
        where TNavigation : INavigationStrategy
    {
        var pageObject = _pageObjectFactory.Create<TPage>(_driver);

        var pageObjectRegistry = _pageObjectRegistryFactory.Create(pageObject);
        pageObjectRegistry?.RegisterComponents(pageObject);

        pageObject.InitializeLazyComponents();

        var navigation = _navigationStrategyFactory.Create<TNavigation>();
        await navigation.Navigate(_driver, pageObject);

        await pageObject.WaitUntilReady();

        return pageObject;
    }
}