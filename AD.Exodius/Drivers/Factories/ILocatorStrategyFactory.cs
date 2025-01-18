using AD.Exodius.Locators;

namespace AD.Exodius.Drivers.Factories;

/// <summary>
/// Represents a factory for creating locator strategies.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface ILocatorStrategyFactory
{
    /// <summary>
    /// Creates a locator strategy of type <typeparamref name="TLocatorStrategy"/> based on the provided values.
    /// </summary>
    /// <typeparam name="TLocatorStrategy">The type of locator strategy to create.</typeparam>
    /// <param name="values">The values used to configure the locator strategy.</param>
    /// <returns>The created locator strategy.</returns>
    public TLocatorStrategy Create<TLocatorStrategy>(params string[] values) where TLocatorStrategy : LocatorStrategy;
}
