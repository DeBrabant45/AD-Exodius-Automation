using AD.Exodius.Components;
using AD.Exodius.Drivers;
using AD.Exodius.Registries;

namespace AD.Exodius.UnitTests.Stubs.Components;

public class StubNavigationActionComponent(IDriver driver, IPageComponentRegistry owner) 
    : PageComponent(driver, owner), INavigationActionComponent
{
    public Task ClickAction(string item)
    {
        return Task.CompletedTask;
    }
}
