using AD.Exodius.Utility.Attributes;

namespace AD.Exodius.Utility.Enums;

public static class EnumExtension
{
    public static string GetNetworkLabel(this Enum value) => value.GetAttributeStringValue<NetworkLabelAttribute>();

    public static string GetHtmlId(this Enum value) => value.GetAttributeStringValue<HtmlElementIdAttribute>();

    public static string GetHtmlText(this Enum value) => value.GetAttributeStringValue<HtmlElementTextAttribute>();

    public static string GetHtmlValue(this Enum value) => value.GetAttributeStringValue<HtmlElementValueAttribute>();

    public static string GetHtmlTextAbbreviation(this Enum value) => value.GetAttributeStringValue<HtmlElementTextAbbreviationAttribute>();

    private static string GetAttributeStringValue<TAttribute>(this Enum value) where TAttribute : Attribute, IAttributeValue
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attributes = fieldInfo?.GetCustomAttributes(typeof(TAttribute), false);

        return attributes != null && attributes.Length > 0
            ? ((IAttributeValue)attributes[0]).AttributeValue
            : throw new InvalidOperationException($"{fieldInfo} does not have a custom attribute value!");
    }

    public static IEnumerable<T> GetAllValues<T>() where T : Enum
    {
        return Enum
            .GetValues(typeof(T))
            .Cast<T>();
    }
}
