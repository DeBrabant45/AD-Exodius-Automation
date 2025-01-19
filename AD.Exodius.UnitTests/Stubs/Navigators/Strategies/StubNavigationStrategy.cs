using AD.Exodius.Drivers;
using AD.Exodius.Navigators.Strategies;
using AD.Exodius.Pages;

namespace AD.Exodius.UnitTests.Stubs.Navigators.Strategies;

public class StubNavigationStrategy : INavigationStrategy
{
    public Task Navigate<TPage>(IDriver driver, TPage page) where TPage : IPageObject
    {
        return Task.CompletedTask;
    }
}
