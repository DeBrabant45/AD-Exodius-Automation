namespace AD.Exodius.Locators;

/// <summary>
/// Represents a locator strategy based on an HTML text.
/// </summary>
/// <remarks>
/// <para>This strategy selects elements with a specific Text value.</para> 
/// <para>Note: The "text=" prefix should not be included in your value.</para>
/// </remarks>
/// <author>Aaron DeBrabant</author>
public class ByText : LocatorStrategy
{
    private readonly string convertedLocator;

    public ByText(string value) : base(value)
    {
        convertedLocator = $"text={Value}";
    }

    public ByText(string relativePath, string value) 
        : base(value)
    {
        convertedLocator = $"xpath=//{relativePath}[text()='{Value}']";
    }

    public override string Convert() => convertedLocator;
}
