namespace AD.Exodius.Navigators.Actions;

/// <summary>
/// Defines an action to be executed after navigation to a page or component has completed.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IAfterNavigationAction
{
    /// <summary>
    /// Executes any post-navigation logic or cleanup after the navigation has finished.
    /// </summary>
    /// <returns>A task representing the asynchronous post-navigation operation.</returns>
    public Task ExecuteAfter();
}