using NSubstitute;
using AD.Exodius.Navigators.Strategies;
using AD.Exodius.Pages;
using AD.Exodius.Drivers;

namespace AD.Exodius.UnitTests.Navigators.Strategies;

public class ByActionTests
{
    private readonly ByAction _sut;
    private readonly IDriver _mockDriver;
    private readonly IPageObject _mockPageObject;

    public ByActionTests()
    {
        _sut = new ByAction();
        _mockDriver = Substitute.For<IDriver>();
        _mockPageObject = Substitute.For<IPageObject>();
    }

    [Fact]
    public async Task Navigate_Should_InvokeProvidedAction()
    {
        var actionExecuted = false;
        Func<Task> testAction = () =>
        {
            actionExecuted = true;
            return Task.CompletedTask;
        };

        var actions = new Func<Task>[] { testAction };

        await _sut.Navigate(_mockDriver, _mockPageObject, actions);

        Assert.True(actionExecuted, "Action was not executed.");
    }

    [Fact]
    public async Task Navigate_Should_InvokeMultipleActionsInOrder()
    {
        var firstActionExecuted = false;
        var secondActionExecuted = false;

        Func<Task> firstAction = () =>
        {
            firstActionExecuted = true;
            return Task.CompletedTask;
        };

        Func<Task> secondAction = () =>
        {
            secondActionExecuted = firstActionExecuted;
            return Task.CompletedTask;
        };

        var actions = new Func<Task>[] { firstAction, secondAction };

        await _sut.Navigate(_mockDriver, _mockPageObject, actions);

        Assert.True(firstActionExecuted, "First action was not executed.");
        Assert.True(secondActionExecuted, "Second action was not executed after the first.");
    }

    [Fact]
    public async Task Navigate_Should_SkipNullActions_AndExecuteNonNullActions()
    {
        var nonNullActionExecuted = false;

        Func<Task>? nullAction = null;

        Func<Task> nonNullAction = () =>
        {
            nonNullActionExecuted = true;
            return Task.CompletedTask;
        };

        var actions = new Func<Task>?[] { nullAction, nonNullAction };

        await _sut.Navigate(_mockDriver, _mockPageObject, actions!);

        Assert.True(nonNullActionExecuted, "Non-null action was not executed.");
    }
}
