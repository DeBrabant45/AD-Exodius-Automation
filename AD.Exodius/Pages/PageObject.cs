using AD.Exodius.Components;
using AD.Exodius.Drivers;
using AD.Exodius.Registries;

namespace AD.Exodius.Pages;

public class PageObject : PageComponentRegistry, IPageObject
{
    public PageObject(IDriver driver)
        :base(driver)
    {

    }

    public virtual async Task WaitUntilReady()
    {
        var waitSections = GetComponents<IWaitComponent>();

        await Task.WhenAll(waitSections
            .Select(section => section.WaitUntilFullyLoaded()));
    }
}
