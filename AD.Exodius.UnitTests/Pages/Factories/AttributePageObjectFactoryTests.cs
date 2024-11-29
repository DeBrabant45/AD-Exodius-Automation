using NSubstitute;
using AD.Exodius.Driver;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Attributes;
using AD.Exodius.Pages.Factories;
using AD.Exodius.Pages.Helpers;
using AD.Exodius.UnitTests.Stubs.PageObjects;

namespace AD.Exodius.UnitTests.Pages.Factories;

public class AttributePageObjectFactoryTests
{
    private readonly AttributePageObjectFactory _sut;
    private readonly IDriver _mockedDriver;
    private readonly IPageObjectAttributeCache _attributeCache;
    private readonly StubBasicAttributePageObject _stubBasicAttributePage;
    private readonly StubSampleAttributePageObject _stubSampleAttributePage;

    public AttributePageObjectFactoryTests()
    {
        _attributeCache = new PageObjectAttributeCache();
        _mockedDriver = Substitute.For<IDriver>();
        _stubBasicAttributePage = new(_mockedDriver);
        _stubSampleAttributePage = new(_mockedDriver);

        _sut = new AttributePageObjectFactory(
        [   _stubBasicAttributePage, 
            _stubSampleAttributePage
        ], 
        _attributeCache);
    }

    [Theory]
    [MemberData(nameof(GetErrorTestData))]
    public void Constructor_ShouldThrowException_WhenPagesAreNullOrEmpty(IEnumerable<IPageObject> pages)
    {
        var exception = Assert.Throws<ArgumentException>(() => new AttributePageObjectFactory(pages, _attributeCache));

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
    public void Create_ShouldReturn_ExpectedPage()
    {
        var results = _sut.Create<StubBasicAttributePageObject, PageObjectNameAttribute, string>("Basic Attribute");

        Assert.Equal(_stubBasicAttributePage, results);
    }

    [Fact]
    public void Create_ShouldThrowException_WhenPageAttributeIsNotFound()
    {
        var exception = Assert.Throws<InvalidOperationException>(() =>
            _sut.Create<StubSampleAttributePageObject, PageObjectRouteAttribute, string>("/bad-request"));

        Assert.Contains($"No attributes of type", exception.Message);
    }
}
