using AD.Exodius.Navigators.Actions;
using AD.Exodius.Pages;

namespace AD.Exodius.Navigators.Factories;

/// <summary>
/// A factory interface for creating navigator actions based on the specified page.
/// </summary>
/// <author>Aaron DeBrabant</author> 
public interface INavigatorActionFactory
{
    /// <summary>
    /// Creates a navigator action for the specified page type.
    /// </summary>
    /// <typeparam name="TPage">The type of the page for which the navigator action is created.</typeparam>
    /// <param name="page">The page object that requires navigation actions.</param>
    /// <returns>An instance of <see cref="INavigatorAction"/> for the provided page.</returns>
    public INavigatorAction Create<TPage>(TPage page) where TPage : IPageObject;
}
