using Microsoft.Playwright;
using PlaywrightLibrary.Driver;

namespace PlaywrightTests;

public class MockTest
{
    private PageDriver _pageDriver;

    [SetUp]
    public async Task Setup()
    {
        _pageDriver = new PageDriver();
        var options = new BrowserTypeLaunchOptions();
        var url = "https://google.com";
        options.Headless = false;
        await _pageDriver.Start(Browser.Chrome, options);
        await _pageDriver.GoToUrl(url);
    }

    [Test]
    public async Task SimpleTest()
    {
        await _pageDriver.Quit();
        Assert.Pass();
    }
}