using AD.Exodius.Components;
using AD.Exodius.Drivers;
using AD.Exodius.Registries;

namespace AD.Exodius.UnitTests.Stubs.Components;

public class StubLazyPageComponent(IDriver driver, IPageComponentRegistry owner) : LazyPageComponent(driver, owner)
{
    public bool IsInitialized { get; private set; }

    public override void Initialize()
    {
        IsInitialized = true;
    }
}
