using AD.Exodius.Drivers;

namespace AD.Exodius.Pages.Factories;

/// <summary>
/// Represents a factory responsible for creating instances of page objects.
/// </summary>
/// <typeparam name="TPage">The type of the page object to create, which must implement <see cref="IPageObject"/>.</typeparam>
/// <returns>An instance of the requested page object type <typeparamref name="TPage"/>.</returns>
/// <author>Aaron DeBrabant</author>
public interface IPageObjectFactory
{
    /// <summary>
    /// Creates an instance of a page object.
    /// </summary>
    /// <typeparam name="TPage">The type of the page object to create.</typeparam>
    /// <returns>An instance of the page object <typeparamref name="TPage"/>.</returns>
    public TPage Create<TPage>(IDriver driver) where TPage : IPageObject;
}
