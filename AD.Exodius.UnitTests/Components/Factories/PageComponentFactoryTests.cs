using AD.Exodius.Components;
using AD.Exodius.Components.Factories;
using AD.Exodius.UnitTests.Stubs.Components;

namespace AD.Exodius.UnitTests.Components.Factories;

public class PageComponentFactoryTests
{
    private IPageComponentFactory _sut;
    private readonly StubBasicPageComponent _stubBasicPageComponent;
    private readonly StubSamplePageComponent _stubSamplePageComponent;

    public PageComponentFactoryTests()
    {
        _stubBasicPageComponent = new StubBasicPageComponent();
        _stubSamplePageComponent = new StubSamplePageComponent();

        _sut = new PageComponentFactory(
        [
            _stubBasicPageComponent,
            _stubSamplePageComponent,
        ]);
    }

    [Theory]
    [MemberData(nameof(GetErrorTestData))]
    public void Constructor_ShouldThrowException_WhenComponentsAreNullOrEmpty(IEnumerable<IPageComponent> components)
    {
        var exception = Assert.Throws<ArgumentException>(() => new PageComponentFactory(components));

        Assert.Equal("No components found in the provided collection from startup!", exception.Message);
    }

    public static TheoryData<IEnumerable<IPageComponent>> GetErrorTestData()
    {
        return
        [
            null,
            [],
        ];
    }

    [Fact]
    public void Create_ShouldReturn_ExpectedComponent()
    {
        var results = _sut.Create<StubBasicPageComponent>();

        Assert.Equal(_stubBasicPageComponent, results);
    }

    [Fact]
    public void Create_ShouldThrowException_WhenRequestedComponentIsNotPresent()
    {
        _sut = new PageComponentFactory([_stubBasicPageComponent]);

        var exception = Assert.Throws<InvalidOperationException>(_sut.Create<StubSamplePageComponent>);

        Assert.Equal($"{typeof(StubSamplePageComponent).Name} does not exist in the provided collection from startup!", exception.Message);
    }
}
