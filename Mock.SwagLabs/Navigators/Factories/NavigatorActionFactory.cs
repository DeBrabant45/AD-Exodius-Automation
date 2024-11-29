using AD.Exodius.Navigators.Actions;
using AD.Exodius.Navigators.Factories;
using AD.Exodius.Pages;

namespace Mock.SwagLabs.Navigators.Factories;

public class NavigatorActionFactory : INavigatorActionFactory
{
    private readonly HashSet<INavigatorAction> _navigatorActions;

    public NavigatorActionFactory(IEnumerable<INavigatorAction> navigatorActions)
    {
        _navigatorActions = navigatorActions.ToHashSet();
    }

    public INavigatorAction Create<TPage>(TPage page) where TPage : IPageObject
    {
        return _navigatorActions.FirstOrDefault() 
            ?? throw new InvalidOperationException();
    }
}
