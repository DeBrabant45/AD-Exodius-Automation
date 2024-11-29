namespace AD.Exodius.Utility.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public sealed class HtmlElementTextAttribute : Attribute, IAttributeValue
{
    public string AttributeValue { get; }

    public HtmlElementTextAttribute(string elementText)
    {
        AttributeValue = elementText;
    }
}
