namespace AD.Exodius.Driver.Factories;

/// <summary>
/// Represents a factory for creating page instances.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IPageFactory
{
    /// <summary>
    /// Creates a page instance associated with the specified browser.
    /// </summary>
    /// <remarks>
    /// Please note, once this is called it will create and launch the page isntance. 
    /// </remarks>
    /// <param name="browser">The browser instance to associate the page with.</param>
    /// <returns>A task representing the asynchronous operation. The task result is the created page instance.</returns>
    public Task<IPage> CreatePage(IBrowser browser);
}