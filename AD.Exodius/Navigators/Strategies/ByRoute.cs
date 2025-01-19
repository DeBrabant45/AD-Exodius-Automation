using AD.Exodius.Drivers;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Extensions;

namespace AD.Exodius.Navigators.Strategies;

/// <summary>
/// Implements navigation by constructing and navigating to a URL route.
/// </summary>
public class ByRoute : INavigationStrategy
{
    public async Task Navigate<TPage>(IDriver driver, TPage page) where TPage : IPageObject
    {
        var pageObjectMetaRoute = page.TryGetRoute(out var route) ? route : page.TryGetPageObjectMeta(out var meta) ? meta.Route : null;

        if (string.IsNullOrEmpty(pageObjectMetaRoute))
            throw new InvalidOperationException($"No Page Meta data as been supplied for Routing on {typeof(TPage).Name}!");

        var newFullPath = driver.BuildUrlWithRoute(pageObjectMetaRoute);
        var currentPath = driver.CurrentUrl();

        if (currentPath == newFullPath)
            return;

        await driver.GoToUrl(newFullPath);
    }
}
