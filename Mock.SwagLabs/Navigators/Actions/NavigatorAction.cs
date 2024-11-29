using AD.Exodius.Navigators.Actions;
using AD.Exodius.Pages;

namespace Mock.SwagLabs.Navigators.Actions;

public class NavigatorAction : INavigatorAction
{
    public Func<Task>[] GetActions<TPage>(TPage page) where TPage : IPageObject
    {
        return [];
    }
}
