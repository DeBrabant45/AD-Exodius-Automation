using AD.Exodius.Components;
using AD.Exodius.Drivers;
using AD.Exodius.Registries;

namespace AD.Exodius.UnitTests.Stubs.Components;

public class StubBasicPageComponent(IDriver driver, IPageComponentRegistry owner) : PageComponent(driver, owner)
{

}
