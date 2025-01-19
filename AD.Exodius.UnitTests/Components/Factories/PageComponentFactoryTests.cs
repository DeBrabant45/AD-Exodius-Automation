using AD.Exodius.Components.Factories;
using AD.Exodius.Drivers;
using AD.Exodius.Pages;
using AD.Exodius.UnitTests.Stubs.Components;
using NSubstitute;

namespace AD.Exodius.UnitTests.Components.Factories;

public class PageComponentFactoryTests
{
    private readonly IPageObject _mockPageObject;
    private readonly IDriver _mockDriver;

    public PageComponentFactoryTests()
    {
        _mockPageObject = Substitute.For<IPageObject>();
        _mockDriver = Substitute.For<IDriver>();
    }

    [Fact]
    public void Create_ShouldThrowArgumentNullException_WhenOwnerIsNull()
    {
        var exception = Assert.Throws<ArgumentNullException>(() =>
            PageComponentFactory.Create<StubBasicPageComponent>(_mockDriver, null));

        Assert.Equal("Value cannot be null. (Parameter 'owner')", exception.Message);
    }

    [Fact]
    public void Create_ShouldThrowMissingMethodException_WhenComponentCannotBeCreated()
    {
        var exception = Assert.Throws<MissingMethodException>(() =>
            PageComponentFactory.Create<NonCreatablePageComponent>(_mockDriver, _mockPageObject));

        Assert.Equal($"Constructor on type '{typeof(NonCreatablePageComponent).FullName}' not found.", exception.Message);
    }

    [Fact]
    public void Create_ShouldReturnExpectedComponent()
    {
        var result = PageComponentFactory.Create<StubBasicPageComponent>(_mockDriver, _mockPageObject);

        Assert.NotNull(result);
        Assert.IsType<StubBasicPageComponent>(result);
    }
}
