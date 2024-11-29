using System.Reflection;
using Xunit.Sdk;

namespace AD.Exodius.Utility.XunitExtensions.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class CustomMemberDataAttribute<TDataSource> : DataAttribute
{
    private readonly string _memberName;

    public CustomMemberDataAttribute(string memberName)
    {
        _memberName = memberName;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        var dataSourceType = typeof(TDataSource);
        var member = dataSourceType.GetMethod(_memberName, BindingFlags.Public | BindingFlags.Static);
        if (member == null)
        {
            throw new ArgumentException($"The method '{_memberName}' was not found in '{dataSourceType.FullName}'.");
        }

        var data = member.Invoke(null, null) as IEnumerable<object[]>;
        if (data == null)
        {
            throw new ArgumentException($"The method '{_memberName}' does not return IEnumerable<object[]>.");
        }

        return data;
    }
}