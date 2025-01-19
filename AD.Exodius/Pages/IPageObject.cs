using AD.Exodius.Registries;

namespace AD.Exodius.Pages;

/// <summary>
/// Represents a page with navigation and component retrieval capabilities.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IPageObject : IPageComponentRegistry
{
    /// <summary>
    /// Asynchronously waits until the page or component is fully ready.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task WaitUntilReady();
}