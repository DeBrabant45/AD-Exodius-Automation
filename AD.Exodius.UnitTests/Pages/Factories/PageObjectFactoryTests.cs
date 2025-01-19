using AD.Exodius.Drivers;
using AD.Exodius.Pages.Factories;
using AD.Exodius.UnitTests.Stubs.PageObjects;
using NSubstitute;

namespace AD.Exodius.UnitTests.Pages.Factories;

public class PageObjectFactoryTests
{
    private PageObjectFactory _sut;
    private readonly IDriver _mockedDriver;

    public PageObjectFactoryTests()
    {
        _mockedDriver = Substitute.For<IDriver>();
        _sut = new PageObjectFactory();
    }

    [Fact]
    public void Create_ShouldReturn_ExpectedPage()
    {
        var result = _sut.Create<StubBasicPageObject>(_mockedDriver);
        Assert.IsType<StubBasicPageObject>(result);
    }
}
