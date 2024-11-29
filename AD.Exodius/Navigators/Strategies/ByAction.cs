using AD.Exodius.Driver;
using AD.Exodius.Pages;

namespace AD.Exodius.Navigators.Strategies;

public class ByAction : INavigationStrategy
{
    public async Task Navigate<TPage>(IDriver driver, TPage page, Func<Task>[]? actions = null) where TPage : IPageObject
    {
        if (actions == null)
            return;

        foreach (var action in actions)
        {
            if (action != null)
            {
                await action.Invoke();
            }
        }
    }
}
