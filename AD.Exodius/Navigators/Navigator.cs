using AD.Exodius.Components;
using AD.Exodius.Drivers;
using AD.Exodius.Navigators.Actions;
using AD.Exodius.Navigators.Factories;
using AD.Exodius.Navigators.Strategies;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Extensions;
using AD.Exodius.Pages.Factories;

namespace AD.Exodius.Navigators;

public class Navigator : INavigator
{
    private readonly IDriver _driver;
    private readonly IWaitSection _waitSection;
    private readonly INavigationStrategyFactory _navigationStrategyFactory;
    private readonly IPageObjectFactory _pageFactory;
    private readonly INavigatorActionFactory _navigatorActionFactory;

    public Navigator(IDriver driver,
        IWaitSection contentWaitSection,
        INavigationStrategyFactory navigationStrategyFactory,
        IPageObjectFactory pageFactory,
        INavigatorActionFactory navigatorActionFactory)
    {
        _driver = driver;
        _waitSection = contentWaitSection;
        _navigationStrategyFactory = navigationStrategyFactory;
        _pageFactory = pageFactory;
        _navigatorActionFactory = navigatorActionFactory;
    }

    public virtual async Task<TPage> GoTo<TPage, TNavigation>()
        where TPage : IPageObject
        where TNavigation : INavigationStrategy
    {
        await _waitSection.WaitUntilFullyLoaded();

        var page = _pageFactory.Create<TPage>();
        page.LazyInitialize();

        var navigatorAction = _navigatorActionFactory.Create(page);

        if (navigatorAction is IBeforeNavigationAction beforeAction)
            await beforeAction.ExecuteBefore();

        var navigation = _navigationStrategyFactory.Create<TNavigation>();
        await navigation.Navigate(_driver, page, navigatorAction.GetActions(page));

        if (navigatorAction is IAfterNavigationAction afterAction)
            await afterAction.ExecuteAfter();

        await _waitSection.WaitUntilFullyLoaded();

        return page;
    }
}
