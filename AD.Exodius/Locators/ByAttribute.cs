namespace AD.Exodius.Locators;

/// <summary>
/// Represents a locator strategy based on an HTML attribute.
/// </summary>
/// <remarks>
/// <para>This strategy selects elements with a specific attribute value.</para>
/// </remarks>
/// <author>Aaron DeBrabant</author>
public class ByAttribute : LocatorStrategy
{
    private readonly string _attributeId;

    public ByAttribute(string attributeId, string value) 
        : base(value)
    {
        _attributeId = attributeId;
    }

    public override string Convert() => $"xpath=//*[@{_attributeId}='{Value}']";
}
