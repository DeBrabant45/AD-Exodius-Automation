using AD.Exodius.Elements;

namespace AD.Exodius.Driver.Services;

/// <summary>
/// Represents a service for navigating web pages.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface INavigationService
{
    /// <summary>
    /// Navigates to the specified URL.
    /// </summary>
    /// <param name="url">The URL to navigate to.</param>
    /// <returns>A task representing the asynchronous navigation operation.</returns>
    public Task GoToUrl(string url);

    /// <summary>
    /// Refreshes the current page.
    /// </summary>
    /// <returns>A task representing the asynchronous refresh operation.</returns>
    public Task Refresh();

    /// <summary>
    /// Switches to the default page.
    /// </summary>
    public void SwitchToDefaultPage();

    /// <summary>
    /// Switches to the page at the specified index.
    /// </summary>
    /// <param name="index">The index of the page to switch to.</param>
    public void SwitchToPage(int index);

    /// <summary>
    /// Switches to a new page triggered by clicking the specified element.
    /// </summary>
    /// <param name="clickableElement">The clickable element that triggers the navigation.</param>
    /// <returns>A task representing the asynchronous navigation operation.</returns>
    public Task SwitchToNewPage(IClickElement clickableElement);

    /// <summary>
    /// Cancels the request for the specified URL.
    /// </summary>
    /// <param name="url">The URL of the request to abort.</param>
    /// <returns>A task representing the asynchronous request cancellation operation.</returns>
    public Task CancelRequest(string url);

    /// <summary>
    /// Gets the current URL of the page.
    /// </summary>
    /// <returns>The current URL of the page.</returns>
    public string CurrentUrl();

    /// <summary>
    /// Builds a URL by appending the specified route to the base URL.
    /// </summary>
    /// <param name="route">The route to be appended to the base URL.</param>
    /// <returns>The complete URL consisting of the base URL and the specified route.</returns>
    public string BuildUrlWithRoute(string route);
}