using AD.Exodius.Navigators.Actions;
using AD.Exodius.Pages;

namespace AD.Exodius.UnitTests.Stubs.Navigators.Actions;

public class StubAfterNavigatorAction : IAfterNavigationAction, INavigatorAction
{
    public bool HadExecutedAfterRun { get; private set; }

    public Task ExecuteAfter()
    {
        HadExecutedAfterRun = true;

        return Task.CompletedTask;
    }

    public Func<Task>[] GetActions<TPage>(TPage page) where TPage : IPageObject
    {
        return
        [
            () => Task.CompletedTask,
            () => Task.CompletedTask,
        ];
    }
}
