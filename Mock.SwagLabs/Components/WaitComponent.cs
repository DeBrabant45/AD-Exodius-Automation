using AD.Exodius.Components;
using AD.Exodius.Pages;

namespace Mock.SwagLabs.Components;

public class WaitComponent(IDriver driver, IPageObject owner) 
    : PageComponent(driver, owner), IWaitComponent
{
    public Task WaitUntilFullyLoaded()
    {
        return Task.CompletedTask;
    }
}
