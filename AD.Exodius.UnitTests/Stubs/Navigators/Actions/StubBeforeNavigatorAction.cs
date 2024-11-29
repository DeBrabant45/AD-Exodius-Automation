using AD.Exodius.Navigators.Actions;
using AD.Exodius.Pages;

namespace AD.Exodius.UnitTests.Stubs.Navigators.Actions;

public class StubBeforeNavigatorAction : IBeforeNavigationAction, INavigatorAction
{
    public bool HasExecutedBeforeRun { get; private set; }

    public Task ExecuteBefore()
    {
        HasExecutedBeforeRun = true;

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


public class StubNavigatorAction : INavigatorAction
{
    public Func<Task>[] GetActions<TPage>(TPage page) where TPage : IPageObject
    {
        return
        [
           () => Task.CompletedTask,
           () => Task.CompletedTask,
        ];
    }
}