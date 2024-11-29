namespace AD.Exodius.Utility.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public sealed class HtmlElementTextAbbreviationAttribute : Attribute, IAttributeValue
{
    public string AttributeValue { get; }

    public HtmlElementTextAbbreviationAttribute(string elementTextAbbreviation)
    {
        AttributeValue = elementTextAbbreviation;
    }
}
