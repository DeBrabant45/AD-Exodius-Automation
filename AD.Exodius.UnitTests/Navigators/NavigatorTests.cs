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
    private readonly Navigator _sut;
    private readonly IDriver _mockDriver;
    private readonly IPageObject _stubPageObject;
    private readonly IPageObjectFactory _mockPageObjectFactory;
    private readonly IPageObjectRegistryFactory _mockPageObjectRegistryFactory;
    private readonly INavigationStrategyFactory _mockNavigationStrategyFactory;

    public NavigatorTests()
    {
        _mockDriver = Substitute.For<IDriver>();
        _stubPageObject = new StubBasicPageObject(_mockDriver);
        _mockPageObjectFactory = Substitute.For<IPageObjectFactory>();
        _mockPageObjectRegistryFactory = Substitute.For<IPageObjectRegistryFactory>();
        _mockNavigationStrategyFactory = Substitute.For<INavigationStrategyFactory>();

        _sut = new Navigator(
            _mockDriver,
            _mockPageObjectFactory, 
            _mockPageObjectRegistryFactory, 
            _mockNavigationStrategyFactory);
    }

    [Fact]
    public async Task GoTo_Should_RunInOrder()
    {
        var stubNavigation = new StubNavigationStrategy();

        _mockPageObjectFactory.Create<IPageObject>(_mockDriver).Returns(_stubPageObject);
        _mockNavigationStrategyFactory.Create<INavigationStrategy>().Returns(stubNavigation);

        await _sut.GoTo<IPageObject, INavigationStrategy>();

        Received.InOrder(() =>
        {
            _mockPageObjectFactory.Create<IPageObject>(_mockDriver);

            _stubPageObject.InitializeLazyComponents();

            _mockNavigationStrategyFactory.Create<INavigationStrategy>();

            stubNavigation.Navigate(_mockDriver, _stubPageObject);

            _stubPageObject.WaitUntilReady();
        });
    }
}
