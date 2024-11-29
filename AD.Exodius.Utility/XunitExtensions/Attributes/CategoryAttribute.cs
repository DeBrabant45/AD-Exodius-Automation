using AD.Exodius.Utility.Enums;
using Xunit.Sdk;

namespace AD.Exodius.Utility.XunitExtensions.Attributes;

[TraitDiscoverer("AD.Exodius.Utility.XunitExtensions.Discoveries.CategoryDiscoverer", "AD.Exodius.Utility")]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class CategoryAttribute : Attribute, ITraitAttribute
{
    public CategoryAttribute(TestCategory category)
    {
        Name = category.ToString();
    }

    public string Name { get; }
}
