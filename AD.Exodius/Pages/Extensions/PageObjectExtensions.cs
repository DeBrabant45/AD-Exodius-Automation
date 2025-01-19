using AD.Exodius.Pages.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace AD.Exodius.Pages.Extensions;

public static class PageObjectExtensions
{
    /// <summary>
    /// Retrieves the route associated with the specified page type using the <see cref="PageObjectRouteAttribute"/>.
    /// </summary>
    /// <typeparam name="TPage">The type of the page object.</typeparam>
    /// <param name="page">The page instance for which to get the route.</param>
    /// <returns>The route associated with the page.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no route is found for the specified page type.</exception>
    public static string GetRoute<TPage>(this TPage page) where TPage : IPageObject
    {
        var routeAttribute = typeof(TPage).GetCustomAttribute<PageObjectRouteAttribute>();

        return routeAttribute != null
            ? routeAttribute.Route
            : throw new InvalidOperationException($"No route found for the page {typeof(TPage).Name}");
    }

    /// <summary>
    /// Attempts to retrieve the route defined by the <see cref="PageObjectRouteAttribute"/> for the specified page type.
    /// </summary>
    /// <typeparam name="TPage">The type of the page object, which must implement <see cref="IPageObject"/>.</typeparam>
    /// <param name="page">The instance of the page object.</param>
    /// <param name="route">
    /// When this method returns, contains the route if the attribute is found; otherwise, <c>null</c>.
    /// </param>
    /// <returns>
    /// <c>true</c> if the route is successfully retrieved; otherwise, <c>false</c>.
    /// </returns>
    public static bool TryGetRoute<TPage>(this TPage page, [NotNullWhen(true)] out string? route) where TPage : IPageObject
    {
        var attribute = typeof(TPage).GetCustomAttribute<PageObjectRouteAttribute>();
        route = attribute?.Route;

        return attribute != null;
    }

    /// <summary>
    /// Retrieves the name associated with the specified page type using the <see cref="PageObjectNameAttribute"/>.
    /// </summary>
    /// <typeparam name="TPage">The type of the page object.</typeparam>
    /// <param name="page">The page instance for which to get the name.</param>
    /// <returns>The name associated with the page.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no name is found for the specified page type.</exception>
    public static string GetName<TPage>(this TPage page) where TPage : IPageObject
    {
        var nameAttribute = typeof(TPage).GetCustomAttribute<PageObjectNameAttribute>();

        return nameAttribute != null
            ? nameAttribute.Name
            : throw new InvalidOperationException($"No name found for the page {typeof(TPage).Name}");
    }

    /// <summary>
    /// Attempts to retrieve the name of the page from the <see cref="PageObjectNameAttribute"/> applied to the page type.
    /// </summary>
    /// <typeparam name="TPage">The type of the page implementing <see cref="IPageObject"/>.</typeparam>
    /// <param name="page">The page instance from which to retrieve the name.</param>
    /// <param name="name">
    /// When this method returns, contains the name specified in the <see cref="PageObjectNameAttribute"/> 
    /// if the attribute is present on the page type; otherwise, <c>null</c>.
    /// </param>
    /// <returns>
    /// <c>true</c> if the <see cref="PageObjectNameAttribute"/> is found on the page type; otherwise, <c>false</c>.
    /// </returns>
    public static bool TryGetName<TPage>(this TPage page, [NotNullWhen(true)] out string? name) where TPage : IPageObject
    {
        var attribute = typeof(TPage).GetCustomAttribute<PageObjectNameAttribute>();
        name = attribute?.Name;

        return attribute != null;
    }

    /// <summary>
    /// Retrieves the <see cref="PageObjectMetaAttribute"/> associated with the specified page type.
    /// </summary>
    /// <typeparam name="TPage">The type of the page object.</typeparam>
    /// <param name="page">The instance of the page object.</param>
    /// <returns>The <see cref="PageObjectMetaAttribute"/> associated with the page type.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if no <see cref="PageObjectMetaAttribute"/> is found for the specified page type.
    /// </exception>
    public static PageObjectMetaAttribute GetPageObjectMeta<TPage>(this TPage page) where TPage : IPageObject
    {
        return typeof(TPage).GetCustomAttribute<PageObjectMetaAttribute>()
            ?? throw new InvalidOperationException($"No Page Object Meta found for the page {typeof(TPage).Name}");
    }

    /// <summary>
    /// Attempts to retrieve the <see cref="PageObjectMetaAttribute"/> from the specified page object type.
    /// </summary>
    /// <typeparam name="TPage">The type of the page object that is being checked for the attribute.</typeparam>
    /// <param name="page">The instance of the page object. This parameter is required for method syntax but not used directly.</param>
    /// <param name="meta">When this method returns, contains the <see cref="PageObjectMetaAttribute"/> if found; otherwise, <c>null</c>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="PageObjectMetaAttribute"/> is found on the page object type; otherwise, <c>false</c>.
    /// </returns>
    public static bool TryGetPageObjectMeta<TPage>(this TPage page, [NotNullWhen(true)] out PageObjectMetaAttribute? meta) where TPage : IPageObject
    {
        meta = typeof(TPage).GetCustomAttribute<PageObjectMetaAttribute>();

        return meta != null;
    }
}
