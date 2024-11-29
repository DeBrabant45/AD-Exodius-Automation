namespace AD.Exodius.Locators;

/// <summary>
/// Represents a base class for defining locator strategies used in element location.
/// </summary>
/// <author>Aaron DeBrabant</author>
public abstract class LocatorStrategy
{
    protected LocatorStrategy(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the value representing the locator strategy.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Converts the locator strategy to its string representation.
    /// </summary>
    /// <returns>The string representation of the locator strategy.</returns>
    public abstract string Convert();
}
