using AD.Exodius.Navigators.Strategies;

namespace AD.Exodius.Navigators.Factories;

/// <summary>
/// Defines a factory for creating navigation strategy instances.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface INavigationStrategyFactory
{
    /// <summary>
    /// Creates an instance of a navigation strategy.
    /// </summary>
    /// <typeparam name="TNavigation">The type of navigation strategy to create, which must implement <see cref="INavigationStrategy"/>.</typeparam>
    /// <returns>An instance of the specified navigation strategy.</returns>
    INavigationStrategy Create<TNavigation>() where TNavigation : INavigationStrategy;
}
