using AD.Exodius.Driver;
using AD.Exodius.Pages;

namespace AD.Exodius.Navigators.Strategies;

/// <summary>
/// Defines a strategy for navigating to a specific page.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface INavigationStrategy
{
    /// <summary>
    /// Navigates to the specified page using the provided driver and optional actions.
    /// </summary>
    /// <typeparam name="TPage">The type of the page to navigate to, which must implement <see cref="IPageObject"/>.</typeparam>
    /// <param name="driver">The driver used to perform the navigation.</param>
    /// <param name="page">The page to navigate to.</param>
    /// <param name="actions">Optional array of actions to be executed before or after navigation.</param>
    /// <returns>A task representing the asynchronous navigation operation.</returns>
    public Task Navigate<TPage>(IDriver driver, TPage page, Func<Task>[]? actions = null) where TPage : IPageObject;
}
