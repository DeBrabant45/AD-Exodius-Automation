using NSubstitute;
using AD.Exodius.Components;
using AD.Exodius.Driver;
using AD.Exodius.Pages;
using AD.Exodius.UnitTests.Stubs.Components;

namespace AD.Exodius.UnitTests.Pages;

public class PageObjectTests
{
    private readonly PageObject _sut;

    public PageObjectTests()
    {
        var mockedDriver = Substitute.For<IDriver>();
        _sut = new PageObject(mockedDriver);
    }

    [Fact]
    public void AddComponent_Should_StoreComponent()
    {
        var stubComponent = new StubBasicPageComponent();

        _sut.AddComponent(stubComponent);
    }

    [Fact]
    public void AddComponents_Should_StoreComponents()
    {
        var stubComponents = new List<IPageComponent>
        {
            new StubBasicPageComponent(),
            new StubBasicPageComponent(),
            new StubBasicPageComponent(),
        };

        _sut.AddComponents(stubComponents);
    }

    [Fact]
    public void GetComponent_ShouldReturn_ExpectedResults()
    {
        var stubComponent = new StubBasicPageComponent();

        _sut.AddComponent(stubComponent);
        var results = _sut.GetComponent<StubBasicPageComponent>();

        Assert.Equal(stubComponent, results);
    }

    [Fact]
    public void GetComponents_ShouldReturn_ExpectedResults()
    {
        var stubComponents = new List<IPageComponent>
        {
            new StubBasicPageComponent(),
            new StubBasicPageComponent(),
            new StubBasicPageComponent(),
        };

        _sut.AddComponents(stubComponents);
        var results = _sut.GetComponents<StubBasicPageComponent>();

        Assert.Equal(stubComponents, results);
        Assert.True(results.Count == stubComponents.Count);
    }
}
