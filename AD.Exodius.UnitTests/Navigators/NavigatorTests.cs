using AD.Exodius.Drivers;
using AD.Exodius.Navigators;
using AD.Exodius.Navigators.Strategies;
using AD.Exodius.Navigators.Strategies.Factories;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Factories;
using AD.Exodius.UnitTests.Stubs.Navigators.Strategies;
using AD.Exodius.UnitTests.Stubs.PageObjects;
using NSubstitute;

namespace AD.Exodius.UnitTests.Navigators;

public class NavigatorTests
{
    private readonly IDriver _mockDriver;
    private readonly INavigationStrategyFactory _mockNavigationStrategyFactory;
    private readonly IPageObjectFactory _mockPageFactory;
    private readonly IPageObject _stubPageObject;
    private readonly Navigator _sut;

    public NavigatorTests()
    {
        _mockDriver = Substitute.For<IDriver>();
        _mockPageFactory = Substitute.For<IPageObjectFactory>();
        _stubPageObject = new StubBasicPageObject(_mockDriver);

        _mockNavigationStrategyFactory = Substitute.For<INavigationStrategyFactory>();

        _sut = new Navigator(_mockDriver, _mockPageFactory, _mockNavigationStrategyFactory);
    }

    [Fact]
    public async Task GoTo_Should_RunInOrder()
    {
        var stubNavigation = new StubNavigationStrategy();

        _mockPageFactory.Create<IPageObject>(_mockDriver).Returns(_stubPageObject);
        _mockNavigationStrategyFactory.Create<INavigationStrategy>().Returns(stubNavigation);

        await _sut.GoTo<IPageObject, INavigationStrategy>();

        Received.InOrder(() =>
        {
            _mockPageFactory.Create<IPageObject>(_mockDriver);

            _stubPageObject.InitializeLazyComponents();

            _mockNavigationStrategyFactory.Create<INavigationStrategy>();

            stubNavigation.Navigate(_mockDriver, _stubPageObject);

            _stubPageObject.WaitUntilReady();
        });
    }
}
