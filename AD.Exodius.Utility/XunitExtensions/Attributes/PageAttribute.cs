using Xunit.Sdk;

namespace AD.Exodius.Utility.XunitExtensions.Attributes;

[TraitDiscoverer("AD.Exodius.Utility.XunitExtensions.Discoveries.PageDiscoverer", "AD.Exodius.Utility")]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class PageAttribute : Attribute, ITraitAttribute
{
    public PageAttribute(string pageName)
    {
        Name = pageName;
    }

    public string Name { get; }
}
