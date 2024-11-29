namespace AD.Exodius.Locators;

/// <summary>
/// Represents a locator strategy based on an HTML css selector.
/// </summary>
/// <remarks>
/// <para>This strategy selects elements with a specific CSS Selector value.</para>
/// <para>Note: The "css=" prefix should not be included in your value.</para>
/// </remarks>
/// <author>Aaron DeBrabant</author>
public class ByCss : LocatorStrategy
{
    public ByCss(string value) : base(value)
    {
    }

    public override string Convert() => $"css={Value}";
}
