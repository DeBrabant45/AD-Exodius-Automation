using AD.Exodius.Components;

namespace AD.Exodius.Pages;

/// <summary>
/// Represents a page with navigation and component retrieval capabilities.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IPageObject
{
    /// <summary>
    /// Adds a single page component to the current page.
    /// </summary>
    /// <param name="component">The page component to add.</param>
    public void AddComponent(IPageComponent component);

    /// <summary>
    /// Adds multiple page components to the current page.
    /// Duplicates are ignored automatically by the underlying data structure.
    /// </summary>
    /// <param name="components">An enumerable collection of page components to add.</param>
    public void AddComponents(IEnumerable<IPageComponent> components);

    /// <summary>
    /// Retrieves a specific component of the page.
    /// </summary>
    /// <typeparam name="TPageComponent">The type of the page component to retrieve, which must implement <see cref="IPageComponent"/>.</typeparam>
    /// <returns>The requested page component.</returns>
    public TPageComponent GetComponent<TPageComponent>() where TPageComponent : IPageComponent;

    /// <summary>
    /// Retrieves a list of components of the page.
    /// </summary>
    /// <typeparam name="TPageComponent">The type of the page components to retrieve, which must implement <see cref="IPageComponent"/>.</typeparam>
    /// <returns>A list of the requested page components.</returns>
    public List<TPageComponent> GetComponents<TPageComponent>() where TPageComponent : IPageComponent;
}
