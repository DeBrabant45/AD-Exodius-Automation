using AD.Exodius.Components;

namespace Mock.SwagLabs.Components.Sections;

public class WaitSection : IWaitSection
{
    public Task WaitUntilFullyLoaded()
    {
        return Task.CompletedTask;
    }
}
