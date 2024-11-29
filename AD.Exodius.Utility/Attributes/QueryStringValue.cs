namespace AD.Exodius.Utility.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class QueryStringValue : Attribute
{
    public string Value { get; }

    public QueryStringValue(string value)
    {
        Value = value;
    }
}
