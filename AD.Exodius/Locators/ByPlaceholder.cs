namespace AD.Exodius.Locators;

/// <summary>
/// Represents a locator strategy based on an HTML placeholder.
/// </summary>
/// <remarks>
/// <para>This strategy selects elements with a specific placeholder value.</para>
/// <para>Note: The "placeholder=" prefix should not be included in your value.</para>
/// </remarks>
/// <author>Aaron DeBrabant</author>
public class ByPlaceholder : LocatorStrategy
{
    public ByPlaceholder(string value) : base(value)
    {
    }

    public override string Convert() => $"placeholder={Value}";
}
