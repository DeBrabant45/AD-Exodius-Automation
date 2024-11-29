namespace AD.Exodius.Navigators.Actions;

/// <summary>
/// Defines an action to be executed before navigation to a page or component begins.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IBeforeNavigationAction
{
    /// <summary>
    /// Executes any pre-navigation logic or preparation before the navigation starts.
    /// </summary>
    /// <returns>A task representing the asynchronous pre-navigation operation.</returns>
    public Task ExecuteBefore();
}
