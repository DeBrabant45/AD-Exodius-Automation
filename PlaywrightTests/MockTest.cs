using PlaywrightLibrary.Configuration;
using PlaywrightLibrary.Driver;
using PlaywrightLibrary.Elements;

namespace PlaywrightTests;

[TestFixture]
public class MockTest
{
    private IDriver _driver;
    private TestSettings _settings;

    public MockTest()
    {
        var browserFactory = new BrowserFactory();
        var elementFactory = new ElementFactory();
        _settings = ConfigurationReader.Read();
        _driver = new PageDriver(browserFactory, elementFactory, _settings);
    }

    [SetUp]
    public async Task Setup()
    {
        await _driver.GoToUrl(_settings.ApplicationUrl);
    }

    [Test]
    public async Task SimpleTest()
    {
        TextInputElement NameField = _driver.FindElementById<TextInputElement>("name");
        await NameField.TypeInput("Hello");
        var actualText = await NameField.Text();
        Assert.AreEqual("Hello", actualText);
    }
}