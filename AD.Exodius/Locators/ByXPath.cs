namespace AD.Exodius.Locators;

/// <summary>
/// Represents a locator strategy based on an HTML xpath.
/// </summary>
/// <remarks>
/// <para>This strategy selects elements with a specific XPath value.</para>
/// <para>Note: The "xpath=" prefix should not be included in your value and should start with //.</para>
/// </remarks>
/// <author>Aaron DeBrabant</author>
public class ByXPath : LocatorStrategy
{
    public ByXPath(string value) : base(value)
    {

    }

    public override string Convert() => $"xpath={Value}";
}