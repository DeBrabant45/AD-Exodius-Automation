using Microsoft.Playwright;
using PlaywrightLibrary.Driver;
using PlaywrightLibrary.Elements;

namespace PlaywrightTests;

public class MockTest
{
    private PageDriver _pageDriver;

    [SetUp]
    public async Task Setup()
    {
        _pageDriver = new PageDriver();
        var options = new BrowserTypeLaunchOptions();
        var url = "https://automationintesting.online/";
        options.Headless = false;
        await _pageDriver.Start(Browser.Chrome, options);
        await _pageDriver.GoToUrl(url);
    }

    [Test]
    public async Task SimpleTest()
    {
        TextInputElement NameField = _pageDriver.FindElementById<TextInputElement>("name");
        await NameField.TypeInput("Hello");
        await _pageDriver.Quit();
        Assert.Pass();
    }
}