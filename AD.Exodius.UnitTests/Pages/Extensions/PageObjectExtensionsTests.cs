using AD.Exodius.Drivers;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Extensions;
using AD.Exodius.UnitTests.Stubs.PageObjects;
using NSubstitute;

namespace AD.Exodius.UnitTests.Pages.Extensions;

public class PageObjectExtensionsTests
{
    private readonly IDriver _mockedDriver;
    private readonly PageObject _pageObject;
    private readonly StubMetaPageObject _metaPageObject;
    private readonly StubBasicAttributePageObject _attributePageObject;

    public PageObjectExtensionsTests()
    {
        _mockedDriver = Substitute.For<IDriver>();
        _pageObject = new PageObject(_mockedDriver);
        _metaPageObject = new StubMetaPageObject(_mockedDriver);
        _attributePageObject = new StubBasicAttributePageObject(_mockedDriver);
    }

    [Fact]
    public void GetRoute_ShouldReturnValidRoute_WhenRouteIsFound()
    {
        var results = _attributePageObject.GetRoute();

        Assert.Equal("/basic", results);
    }

    [Fact]
    public void TryGetRoute_ShouldReturnTrueAndValidRoute_WhenRouteIsFound()
    {
        var isRoutePresent = _attributePageObject.TryGetRoute(out var route);

        Assert.True(isRoutePresent);
        Assert.Equal("/basic", route);
    }

    [Fact]
    public void TryGetRoute_ShouldReturnFalseAndNull_WhenRouteIsNotFound()
    {
        var isRoutePresent = _pageObject.TryGetRoute(out var route);

        Assert.False(isRoutePresent);
        Assert.Null(route);
    }

    [Fact]
    public void GetRoute_ShouldThrownException_WhenRouteIsNotFound()
    {
        var exception = Assert.Throws<InvalidOperationException>(() => _pageObject.GetRoute());

        Assert.Contains($"No route found for the page {typeof(PageObject).Name}", exception.Message);
    }

    [Fact]
    public void GetName_ShouldReturnValidName_WhenNameIsFound()
    {
        var results = _attributePageObject.GetName();

        Assert.Equal("Basic Attribute", results);
    }

    [Fact]
    public void TryGetName_ShouldReturnTrueAndValidName_WhenNameIsFound()
    {
        var isNamePresent = _attributePageObject.TryGetName(out var name);

        Assert.True(isNamePresent);
        Assert.Equal("Basic Attribute", name);
    }

    [Fact]
    public void TryGetName_ShouldReturnFalseAndNull_WhenRouteIsNotFound()
    {
        var isNamePresent = _pageObject.TryGetName(out var name);

        Assert.False(isNamePresent);
        Assert.Null(name);
    }

    [Fact]
    public void GetName_ShouldThrownException_WhenRouteIsNotFound()
    {
        var exception = Assert.Throws<InvalidOperationException>(() => _pageObject.GetName());

        Assert.Contains($"No name found for the page {typeof(PageObject).Name}", exception.Message);
    }

    [Fact]
    public void GetPageObjectMeta_ShouldReturnValidMeta_WhenMetaIsFound()
    {
        var meta = _metaPageObject.GetPageObjectMeta();

        Assert.NotNull(meta);
        Assert.Equal("/home", meta.Route);
        Assert.Equal("Example", meta.Name);
        Assert.Equal("test", meta.DomId);
    }

    [Fact]
    public void TryGetPageObjectMeta_ShouldReturnTrueAndValidMeta_WhenMetaIsFound()
    {
        var isMetaPresent = _metaPageObject.TryGetPageObjectMeta(out var meta);

        Assert.True(isMetaPresent);
        Assert.NotNull(meta);
        Assert.Equal("/home", meta.Route);
        Assert.Equal("Example", meta.Name);
        Assert.Equal("test", meta.DomId);
    }

    [Fact]
    public void TryGetPageObjectMeta_ShouldReturnFalseAndNullMeta_WhenMetaIsNotFound()
    {
        var isMetaPresent = _pageObject.TryGetPageObjectMeta(out var meta);

        Assert.False(isMetaPresent);
        Assert.Null(meta);
    }

}
