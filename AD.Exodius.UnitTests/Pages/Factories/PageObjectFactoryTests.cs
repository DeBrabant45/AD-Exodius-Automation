using NSubstitute;
using AD.Exodius.Driver;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Factories;
using AD.Exodius.UnitTests.Stubs.PageObjects;

namespace AD.Exodius.UnitTests.Pages.Factories;

public class PageObjectFactoryTests
{
    private PageObjectFactory _sut;
    private readonly IDriver _mockedDriver;
    private readonly StubBasicPageObject _stubBasicPageObject;
    private readonly StubSamplePageObject _stubSamplePageObject;
    private readonly PageObject _pageObject;

    public PageObjectFactoryTests()
    {
        _mockedDriver = Substitute.For<IDriver>();
        _stubBasicPageObject = new StubBasicPageObject(_mockedDriver);
        _stubSamplePageObject = new StubSamplePageObject(_mockedDriver);
        _pageObject = new PageObject(_mockedDriver);

        _sut = new PageObjectFactory(
        [
            _stubBasicPageObject,
            _stubSamplePageObject
        ]);
    }

    [Theory]
    [MemberData(nameof(GetErrorTestData))]
    public void Constructor_ShouldThrowException_WhenPagesAreNullOrEmpty(IEnumerable<IPageObject> pages)
    {
        var exception = Assert.Throws<ArgumentException>(() => new PageObjectFactory(pages));

        Assert.Equal("No pages provided or found in the provided collection.", exception.Message);
    }

    public static TheoryData<IEnumerable<IPageObject>> GetErrorTestData()
    {
        return
        [
            null,
            [],
        ];
    }

    [Fact]
    public void Constructor_ShouldThrowException_WhenPagesContainDuplicates()
    {
        var pages = new List<IPageObject>
        {
            _stubBasicPageObject,
            _pageObject,
            _stubBasicPageObject
        };

        var exception = Assert.Throws<ArgumentException>(() => new PageObjectFactory(pages));

        Assert.Contains($"Duplicate pages provided: {typeof(StubBasicPageObject).Name}", exception.Message);
    }

    [Fact]
    public void Create_ShouldReturn_ExpectedPage()
    {
        var result = _sut.Create<StubBasicPageObject>();

        Assert.Equal(_stubBasicPageObject, result);
    }

    [Fact]
    public void Create_ShouldThrowException_WhenRequestedPageIsNotPresent()
    {
        _sut = new PageObjectFactory(
        [
            _stubSamplePageObject,
            _pageObject
        ]);

        var exception = Assert.Throws<InvalidOperationException>(() => _sut.Create<StubBasicPageObject>());

        Assert.Contains($"No page of type {typeof(StubBasicPageObject).Name} found.", exception.Message);
    }
}
