using AD.Exodius.Components;
using AD.Exodius.Drivers;
using AD.Exodius.Pages;
using AD.Exodius.Registries;
using AD.Exodius.UnitTests.Stubs.Components;
using NSubstitute;

namespace AD.Exodius.UnitTests.Registries;

public class PageComponentRegistryTests
{
    private readonly PageComponentRegistry _sut;

    public PageComponentRegistryTests()
    {
        var mockedDriver = Substitute.For<IDriver>();
        _sut = new PageComponentRegistry(mockedDriver);
    }

    [Fact]
    public void AddComponent_Should_StoreComponent()
    {
        var stubComponent = _sut.AddComponent<StubBasicPageComponent>();

        Assert.NotNull(stubComponent);
        Assert.IsType<StubBasicPageComponent>(stubComponent);
    }

    [Fact]
    public void GetComponent_ShouldReturn_ExpectedResults()
    {
        var stubComponent = _sut.AddComponent<StubBasicPageComponent>();

        var results = _sut.GetComponent<StubBasicPageComponent>();

        Assert.Equal(stubComponent, results);
    }

    [Fact]
    public void GetComponents_ShouldReturn_ExpectedResults()
    {
        var components = new List<StubBasicPageComponent>()
        {
            _sut.AddComponent<StubBasicPageComponent>(),
            _sut.AddComponent<StubBasicPageComponent>(),
            _sut.AddComponent<StubBasicPageComponent>(),
        };

        var results = _sut.GetComponents<StubBasicPageComponent>();

        Assert.Equal(components, results);
        Assert.True(results.Count == components.Count);
    }

    [Fact]
    public void RemoveComponents_Should_RemovedSpecifiedComponent()
    {
        var component = _sut.AddComponent<StubBasicPageComponent>();

        _sut.RemoveComponent<StubBasicPageComponent>();

        var results = _sut.GetComponents<StubBasicPageComponent>();

        Assert.Empty(results);
        Assert.DoesNotContain(component, results);
    }

    [Fact]
    public void LazyInitialize_Should_InitializeLazyComponents()
    {
        var mockLazyComponent1 = _sut.AddComponent<StubLazyPageComponent>();
        var mockLazyComponent2 = _sut.AddComponent<StubLazyPageComponent>();

        _sut.InitializeLazyComponents();

        Assert.True(mockLazyComponent1.IsInitialized);
        Assert.True(mockLazyComponent2.IsInitialized);
    }

    [Fact]
    public void LazyInitialize_ShouldNotThrowException_WhenNoLazyComponentsExist()
    {
        var stubPageObject = Substitute.For<IPageObject>();
        stubPageObject.GetComponents<ILazyPageComponent>().Returns(new List<ILazyPageComponent>());

        var exception = Record.Exception(() => stubPageObject.InitializeLazyComponents());

        Assert.Null(exception);
    }
}
