using AD.Exodius.Utility.Enums;
using Xunit.Sdk;

namespace AD.Exodius.Utility.XunitExtensions.Attributes;

[TraitDiscoverer("AD.Exodius.Utility.XunitExtensions.Discoveries.TestStageDiscoverer", "AD.Exodius.Utility")]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class TestStageAttribute : Attribute, ITraitAttribute
{
    public TestStageAttribute(TestStage stage)
    {
        Name = stage.ToString();
    }

    public string Name { get; }
}
