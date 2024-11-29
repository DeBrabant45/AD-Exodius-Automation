using NSubstitute;
using AD.Exodius.Components;
using AD.Exodius.Driver;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Extensions;
using AD.Exodius.UnitTests.Stubs.PageObjects;

namespace AD.Exodius.UnitTests.Pages.Extensions;

public class PageObjectExtensionsTests
{
    private readonly IDriver _mockedDriver;
    private readonly StubBasicAttributePageObject _sut;

    public PageObjectExtensionsTests()
    {
        _mockedDriver = Substitute.For<IDriver>();
        _sut = new StubBasicAttributePageObject(_mockedDriver);
    }

    [Fact]
    public void GetRoute_ShouldReturn_ExpectedResults()
    {
        var results = _sut.GetRoute();

        Assert.Equal("/basic", results);
    }

    [Fact]
    public void GetName_ShouldReturn_ExpectedResults()
    {
        var results = _sut.GetName();

        Assert.Equal("Basic Attribute", results);
    }

    [Fact]
    public void GetRoute_ShouldThrownException_WhenRouteIsNotFound()
    {
        var pageObject = new PageObject(_mockedDriver);

        var exception = Assert.Throws<InvalidOperationException>(() => pageObject.GetRoute());

        Assert.Contains($"No route found for the page {typeof(PageObject).Name}", exception.Message);
    }

    [Fact]
    public void GetName_ShouldThrownException_WhenRouteIsNotFound()
    {
        var pageObject = new PageObject(_mockedDriver);

        var exception = Assert.Throws<InvalidOperationException>(() => pageObject.GetName());

        Assert.Contains($"No name found for the page {typeof(PageObject).Name}", exception.Message);
    }

    [Fact]
    public void LazyInitialize_Should_InitializeLazyComponents()
    {
        var mockLazyComponent1 = Substitute.For<ILazyPageComponent>();
        var mockLazyComponent2 = Substitute.For<ILazyPageComponent>();
        var _stubPageObject = Substitute.For<IPageObject>();
        _stubPageObject.GetComponents<ILazyPageComponent>().Returns(
        [
            mockLazyComponent1,
            mockLazyComponent2
        ]);

        _stubPageObject.LazyInitialize();

        mockLazyComponent1.Received(1).Initialize();
        mockLazyComponent2.Received(1).Initialize();
    }

    [Fact]
    public void LazyInitialize_ShouldNotThrowException_WhenNoLazyComponentsExist()
    {
        var _stubPageObject = Substitute.For<IPageObject>();
        _stubPageObject.GetComponents<ILazyPageComponent>().Returns([]);

        var exception = Record.Exception(() => _stubPageObject.LazyInitialize());

        Assert.Null(exception);
    }
}
