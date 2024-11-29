namespace AD.Exodius.Utility.Attributes;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class HtmlElementIdAttribute : Attribute, IAttributeValue
{
    public string AttributeValue { get; }

    public HtmlElementIdAttribute(string elementId)
    {
        AttributeValue = elementId;
    }
}
