namespace AD.Exodius.Utility.Attributes;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class NetworkLabelAttribute : Attribute, IAttributeValue
{
    public string AttributeValue { get; }

    public NetworkLabelAttribute(string label)
    {
        AttributeValue = label;
    }
}
