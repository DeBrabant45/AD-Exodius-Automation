using AD.Exodius.Elements;
using AD.Exodius.Locators;

namespace AD.Exodius.Driver.Services;

/// <summary>
/// Represents a service for finding elements on a web page.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IElementFindService
{
    /// <summary>
    /// Finds a single element on the page using the specified locator strategy and values.
    /// </summary>
    /// <typeparam name="TLocatorStrategy">The type of locator strategy to use for locating the element.</typeparam>
    /// <typeparam name="TElement">The type of element to find.</typeparam>
    /// <param name="values">The values to be used when creating the locator strategy instance.</param>
    /// <returns>The element found on the page.</returns>
    /// <exception cref="InvalidOperationException">Thrown when failed to create an instance of the specified locator strategy.</exception>
    public TElement FindElement<TLocatorStrategy, TElement>(params string[] values) where TLocatorStrategy : LocatorStrategy where TElement : IElement;

    /// <summary>
    /// Finds all elements on the page using the specified locator strategy and values.
    /// </summary>
    /// <typeparam name="TLocatorStrategy">The type of locator strategy to use for locating the elements.</typeparam>
    /// <typeparam name="TElement">The type of elements to find.</typeparam>
    /// <param name="values">The values to be used when creating the locator strategy instance.</param>
    /// <returns>A list of elements found on the page.</returns>
    /// <exception cref="InvalidOperationException">Thrown when failed to create an instance of the specified locator strategy.</exception>
    public Task<List<TElement>> FindAllElements<TLocatorStrategy, TElement>(params string[] values) where TLocatorStrategy : LocatorStrategy where TElement : IElement;
}
