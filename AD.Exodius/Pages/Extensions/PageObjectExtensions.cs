using System.Reflection;
using AD.Exodius.Components;
using AD.Exodius.Pages.Attributes;

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
    /// Initializes all lazy page components within the specified page by calling their <see cref="ILazyPageComponent.Initialize"/> method.
    /// </summary>
    /// <typeparam name="TPage">The type of the page object.</typeparam>
    /// <param name="page">The page instance containing the lazy components to initialize.</param>
    public static void LazyInitialize<TPage>(this TPage page) where TPage : IPageObject
    {
        var lazyComponents = page.GetComponents<ILazyPageComponent>();

        foreach (var lazyComponent in lazyComponents)
        {
            lazyComponent.Initialize();
        }
    }
}
