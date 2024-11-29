using System.Reflection;
using Xunit.Abstractions;

namespace AD.Exodius.Utility.XunitExtensions;

public static class XunitSerializationExtensions
{
    public static void AutoSerialize(this IXunitSerializationInfo info, object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();

        foreach (var property in properties)
        {
            var value = property.GetValue(obj);
            info.AddValue(property.Name, value);
        }
    }

    public static void AutoDeserialize(this IXunitSerializationInfo info, object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();

        foreach (var property in properties)
        {
            var valueType = property.PropertyType;
            var value = info.GetValue(property.Name, valueType);
            property.SetValue(obj, value);
        }
    }
}
