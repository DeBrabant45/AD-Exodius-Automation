using AD.Exodius.Drivers;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Extensions;

namespace AD.Exodius.Navigators.Strategies;

public class ByRoute : INavigationStrategy
{
    public async Task Navigate<TPage>(IDriver driver, TPage page, Func<Task>[]? actions = null) where TPage : IPageObject
    {
        var newFullPath = driver.BuildUrlWithRoute(page.GetRoute());
        var currentPath = driver.CurrentUrl();

        if (currentPath == newFullPath)
            return;

        await driver.GoToUrl(newFullPath);
    }
}
