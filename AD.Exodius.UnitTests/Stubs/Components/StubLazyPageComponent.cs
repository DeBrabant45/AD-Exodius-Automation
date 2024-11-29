using System.Diagnostics;
using AD.Exodius.Components;

namespace AD.Exodius.UnitTests.Stubs.Components;

public class StubLazyPageComponent : ILazyPageComponent
{
    public void Initialize()
    {
        Debug.WriteLine("We ran for tests");
    }
}
