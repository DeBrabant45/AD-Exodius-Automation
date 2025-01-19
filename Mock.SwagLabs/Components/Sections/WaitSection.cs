using AD.Exodius.Components;
using AD.Exodius.Pages;

namespace Mock.SwagLabs.Components.Sections;

public class WaitSection : PageComponent, IWaitComponent
{
    public WaitSection(
        IDriver driver,
        IPageObject owner)
        : base(driver, owner)
    {

    }

    public Task WaitUntilFullyLoaded()
    {
        return Task.CompletedTask;
    }
}
