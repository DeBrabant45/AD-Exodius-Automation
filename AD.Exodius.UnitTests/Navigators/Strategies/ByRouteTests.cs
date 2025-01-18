using NSubstitute;
using AD.Exodius.Navigators.Strategies;
using AD.Exodius.UnitTests.Stubs.PageObjects;
using AD.Exodius.Drivers;

namespace AD.Exodius.UnitTests.Navigators.Strategies;

public class ByRouteTests
{
    private readonly ByRoute _sut;
    private readonly IDriver _mockDriver;
    private readonly StubBasicAttributePageObject _stubAttributePage;

    public ByRouteTests()
    {
        _sut = new ByRoute();
        _mockDriver = Substitute.For<IDriver>();
        _stubAttributePage = new StubBasicAttributePageObject(_mockDriver);
    }

    [Fact]
    public async Task Navigate_Should_GoToCorrectUrl()
    {
        var expectedRoute = "/basic";
        var expectedUrl = "http://example.com/basic";

        _mockDriver.BuildUrlWithRoute(expectedRoute).Returns(expectedUrl);

        await _sut.Navigate(_mockDriver, _stubAttributePage);

        await _mockDriver.Received(1).GoToUrl(expectedUrl);
    }
}
