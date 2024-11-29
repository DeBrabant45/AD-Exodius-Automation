namespace AD.Exodius.Helpers;

/// <summary>
/// Provides utilities for building and manipulating URLs.
/// </summary>
/// <author>Aaron DeBrabant</author>
public class UrlBuilder
{
    /// <summary>
    /// Gets the base URL from the specified current URL.
    /// </summary>
    /// <param name="currentUrl">The current URL from which to extract the base URL. This URL must be a well-formed URI.</param>
    /// <returns>
    /// The base URL derived from the current URL. 
    /// If the current URL contains "/secure/", it includes "/secure" in the base URL.
    /// The returned URL will not have a trailing slash.
    /// </returns>
    /// <exception cref="UriFormatException">Thrown when the currentUrl is not a valid URI.</exception>
    public static string GetBaseUrl(string currentUrl)
    {
        var uri = new Uri(currentUrl);
        var baseUrl = $"{uri.Scheme}://{uri.Host}";

        var path = uri.AbsolutePath;

        if (uri.AbsolutePath.StartsWith("/secure/", StringComparison.OrdinalIgnoreCase))
        {
            baseUrl += "/secure";
        }

        return baseUrl.TrimEnd('/');
    }

    /// <summary>
    /// Appends a route to the specified base URL.
    /// </summary>
    /// <param name="baseUrl">The base URL to which the route will be appended. The base URL should not have a trailing slash.</param>
    /// <param name="route">The route to append to the base URL. This can include leading or trailing slashes.</param>
    /// <returns>
    /// The complete URL with the appended route. 
    /// If the route is null or empty, the base URL is returned as is. 
    /// The returned URL will always end with a trailing slash if a valid route is appended.
    /// </returns>
    public static string AppendRoute(string baseUrl, string route)
    {
        baseUrl = baseUrl.TrimEnd('/');
        route = route?.TrimStart('/').TrimEnd('/');

        return !string.IsNullOrWhiteSpace(route) ? $"{baseUrl}/{route}/" : baseUrl;
    }
}
