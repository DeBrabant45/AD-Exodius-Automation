using NSubstitute;
using AD.Exodius.Components;
using AD.Exodius.Navigators;
using AD.Exodius.Navigators.Actions;
using AD.Exodius.Navigators.Factories;
using AD.Exodius.Navigators.Strategies;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Extensions;
using AD.Exodius.Pages.Factories;
using AD.Exodius.UnitTests.Stubs.Navigators.Actions;
using AD.Exodius.UnitTests.Stubs.Navigators.Strategies;
using AD.Exodius.UnitTests.Stubs.PageObjects;
using AD.Exodius.Drivers;

namespace AD.Exodius.UnitTests.Navigators;

public class NavigatorTests
{
    private readonly IDriver _mockDriver;
    private readonly IWaitSection _mockWaitSection;
    private readonly INavigationStrategyFactory _mockNavigationStrategyFactory;
    private readonly IPageObjectFactory _mockPageFactory;
    private readonly INavigatorActionFactory _mockNavigatorActionFactory;
    private readonly IPageObject _stubPageObject;
    private readonly Navigator _sut;

    public NavigatorTests()
    {
        _mockDriver = Substitute.For<IDriver>();
        _mockWaitSection = Substitute.For<IWaitSection>();
        _mockNavigationStrategyFactory = Substitute.For<INavigationStrategyFactory>();
        _mockPageFactory = Substitute.For<IPageObjectFactory>();
        _mockNavigatorActionFactory = Substitute.For<INavigatorActionFactory>();
        _stubPageObject = new StubBasicPageObject(_mockDriver);

        _sut = new Navigator(_mockDriver, _mockWaitSection, _mockNavigationStrategyFactory, _mockPageFactory, _mockNavigatorActionFactory);
    }

    [Fact]
    public async Task GoTo_Should_RunInOrderWithoutBeforeAndAfterNavigations()
    {
        var stubNavigatorAction = new StubNavigatorAction();
        var stubNavigation = new StubNavigationStrategy();

        _mockPageFactory.Create<IPageObject>().Returns(_stubPageObject);
        _mockNavigatorActionFactory.Create(_stubPageObject).Returns(stubNavigatorAction);
        _mockNavigationStrategyFactory.Create<INavigationStrategy>().Returns(stubNavigation);

        await _sut.GoTo<IPageObject, INavigationStrategy>();

        Received.InOrder(() =>
        {
            _mockWaitSection.WaitUntilFullyLoaded();

            _mockPageFactory.Create<IPageObject>();

            _stubPageObject.LazyInitialize();

            _mockNavigatorActionFactory.Create(_stubPageObject);

            stubNavigatorAction.GetActions(_stubPageObject);

            _mockNavigationStrategyFactory.Create<INavigationStrategy>();

            stubNavigation.Navigate(_mockDriver, _stubPageObject, stubNavigatorAction.GetActions(_stubPageObject));

            _mockWaitSection.WaitUntilFullyLoaded();
        });
    }

    [Fact]
    public async Task GoTo_Should_RunInOrderWithBeforeNavigations()
    {
        var stubNavigation = new StubNavigationStrategy();
        var stubBeforeNavigatorAction = new StubBeforeNavigatorAction();

        _mockPageFactory.Create<IPageObject>().Returns(_stubPageObject);
        _mockNavigatorActionFactory.Create(_stubPageObject).Returns(stubBeforeNavigatorAction);
        _mockNavigationStrategyFactory.Create<INavigationStrategy>().Returns(stubNavigation);

        await _sut.GoTo<IPageObject, INavigationStrategy>();

        Received.InOrder(() =>
        {
            _mockWaitSection.WaitUntilFullyLoaded();

            _mockPageFactory.Create<IPageObject>();

            _stubPageObject.LazyInitialize();

            _mockNavigatorActionFactory.Create(_stubPageObject);

            stubBeforeNavigatorAction.ExecuteBefore();

            stubBeforeNavigatorAction.GetActions(_stubPageObject);

            _mockNavigationStrategyFactory.Create<INavigationStrategy>();

            stubNavigation.Navigate(_mockDriver, _stubPageObject, stubBeforeNavigatorAction.GetActions(_stubPageObject));

            _mockWaitSection.WaitUntilFullyLoaded();
        });
    }

    [Fact]
    public async Task GoTo_Should_RunInOrderWithAfterNavigations()
    {
        var stubNavigation = new StubNavigationStrategy();
        var stubAfterNavigatorAction = new StubAfterNavigatorAction();

        _mockPageFactory.Create<IPageObject>().Returns(_stubPageObject);
        _mockNavigatorActionFactory.Create(_stubPageObject).Returns(stubAfterNavigatorAction);
        _mockNavigationStrategyFactory.Create<INavigationStrategy>().Returns(stubNavigation);

        await _sut.GoTo<IPageObject, INavigationStrategy>();

        Received.InOrder(() =>
        {
            _mockWaitSection.WaitUntilFullyLoaded();

            _mockPageFactory.Create<IPageObject>();

            _stubPageObject.LazyInitialize();

            _mockNavigatorActionFactory.Create(_stubPageObject);

            stubAfterNavigatorAction.GetActions(_stubPageObject);

            _mockNavigationStrategyFactory.Create<INavigationStrategy>();

            stubNavigation.Navigate(_mockDriver, _stubPageObject, stubAfterNavigatorAction.GetActions(_stubPageObject));

            stubAfterNavigatorAction.ExecuteAfter();

            _mockWaitSection.WaitUntilFullyLoaded();
        });
    }

    [Fact]
    public async Task GoTo_Should_RunInOrderWithBeforeAndAfterNavigations()
    {
        var stubNavigation = new StubNavigationStrategy();
        var stubBeforeAndAfterNavigatorAction = new StubBeforeAndAfterNavigatorAction();

        _mockPageFactory.Create<IPageObject>().Returns(_stubPageObject);
        _mockNavigatorActionFactory.Create(_stubPageObject).Returns(stubBeforeAndAfterNavigatorAction);
        _mockNavigationStrategyFactory.Create<INavigationStrategy>().Returns(stubNavigation);

        await _sut.GoTo<IPageObject, INavigationStrategy>();

        Received.InOrder(() =>
        {
            _mockWaitSection.WaitUntilFullyLoaded();

            _mockPageFactory.Create<IPageObject>();

            _stubPageObject.LazyInitialize();

            _mockNavigatorActionFactory.Create(_stubPageObject);

            stubBeforeAndAfterNavigatorAction.ExecuteBefore();

            stubBeforeAndAfterNavigatorAction.GetActions(_stubPageObject);

            _mockNavigationStrategyFactory.Create<INavigationStrategy>();

            stubNavigation.Navigate(_mockDriver, _stubPageObject, stubBeforeAndAfterNavigatorAction.GetActions(_stubPageObject));

            stubBeforeAndAfterNavigatorAction.ExecuteAfter();

            _mockWaitSection.WaitUntilFullyLoaded();
        });
    }

    [Fact]
    public async Task GoTo_Should_ExecuteBeforeNavigationAction()
    {
        var stubBeforeNavigatorAction = new StubBeforeNavigatorAction();

        _mockPageFactory.Create<IPageObject>().Returns(_stubPageObject);
        _mockNavigatorActionFactory.Create(_stubPageObject).Returns(stubBeforeNavigatorAction);

        await _sut.GoTo<IPageObject, INavigationStrategy>();

        Assert.True(stubBeforeNavigatorAction.HasExecutedBeforeRun, "ExecuteBefore was not called.");
    }

    [Fact]
    public async Task GoTo_Should_ExecuteAfterNavigationAction()
    {
        var stubAfterNavigatorAction = new StubAfterNavigatorAction();

        _mockPageFactory.Create<IPageObject>().Returns(_stubPageObject);
        _mockNavigatorActionFactory.Create(_stubPageObject).Returns(stubAfterNavigatorAction);

        await _sut.GoTo<IPageObject, INavigationStrategy>();

        Assert.True(stubAfterNavigatorAction.HadExecutedAfterRun, "ExecuteAfter was not called.");
    }

    [Fact]
    public async Task GoTo_Should_UseCorrectNavigationStrategy()
    {
        var mockNavigatorAction = Substitute.For<INavigatorAction>();
        var mockNavigation = Substitute.For<INavigationStrategy>();

        _mockPageFactory.Create<IPageObject>().Returns(_stubPageObject);
        _mockNavigatorActionFactory.Create(_stubPageObject).Returns(mockNavigatorAction);
        _mockNavigationStrategyFactory.Create<INavigationStrategy>().Returns(mockNavigation);

        await _sut.GoTo<IPageObject, INavigationStrategy>();

        await mockNavigation.Received(1).Navigate(_mockDriver, _stubPageObject, mockNavigatorAction.GetActions(_stubPageObject));
    }
}
