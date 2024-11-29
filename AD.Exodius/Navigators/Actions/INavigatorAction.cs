using AD.Exodius.Pages;

namespace AD.Exodius.Navigators.Actions;

/// <summary>
/// Represents an action to be performed during navigation for a specific page or component.
/// </summary>
/// <author>Aaron DeBrabant</author> 
public interface INavigatorAction
{
    /// <summary>
    /// Retrieves the set of actions to be executed during navigation for the specified page.
    /// </summary>
    /// <typeparam name="TPage">The type of the page for which the actions are retrieved.</typeparam>
    /// <param name="page">The page object for which the navigation actions are needed.</param>
    /// <returns>An array of asynchronous tasks representing the navigation actions.</returns>
    public Func<Task>[] GetActions<TPage>(TPage page) where TPage : IPageObject;
}
