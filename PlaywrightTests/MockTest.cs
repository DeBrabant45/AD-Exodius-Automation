using PlaywrightLibrary.Configuration;
using PlaywrightLibrary.Driver;
using PlaywrightLibrary.Elements;

namespace PlaywrightTests;

[TestFixture]
public class MockTest
{
    private IDriver _driver;

    [SetUp]
    public async Task Setup()
    {
        _driver = new PageDriver();
        var testSettings = ConfigurationReader.Read();
        await _driver.Start(testSettings);
        await _driver.GoToUrl(testSettings.ApplicationUrl);
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