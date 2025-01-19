using AD.Exodius.Drivers;
using AD.Exodius.Navigators.Strategies;
using AD.Exodius.Navigators.Strategies.Factories;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Factories;

namespace AD.Exodius.Navigators;

public class Navigator : INavigator
{
    private readonly IDriver _driver;
    private readonly IPageObjectFactory _pageFactory;
    private readonly INavigationStrategyFactory _navigationStrategyFactory;

    public Navigator(
        IDriver driver,
        IPageObjectFactory pageFactory,
        INavigationStrategyFactory navigationStrategyFactory)
    {
        _driver = driver;
        _pageFactory = pageFactory;
        _navigationStrategyFactory = navigationStrategyFactory;
    }

    public virtual async Task<TPage> GoTo<TPage, TNavigation>()
        where TPage : IPageObject
        where TNavigation : INavigationStrategy
    {
        var page = _pageFactory.Create<TPage>(_driver);
        page.InitializeLazyComponents();

        var navigation = _navigationStrategyFactory.Create<TNavigation>();
        await navigation.Navigate(_driver, page);

        await page.WaitUntilReady();

        return page;
    }
}