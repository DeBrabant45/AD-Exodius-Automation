using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightLibrary.Driver;

public class BrowserFactory
{
    public Task<IBrowser> CreateBrowser(IPlaywright playwright, Browser browserType, BrowserTypeLaunchOptions options)
    {
        switch (browserType)
        {
            case Browser.Chrome:
                return CreateChromeDriver(playwright, options);
            case Browser.Firefox:
                return CreateFirefoxDriver(playwright, options);
            default:
                throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
        }
    }

    private async Task<IBrowser> CreateChromeDriver(IPlaywright playwright, BrowserTypeLaunchOptions options)
    {
        return await playwright.Chromium.LaunchAsync(options);
    }

    private async Task<IBrowser> CreateFirefoxDriver(IPlaywright playwright, BrowserTypeLaunchOptions options)
    {
        return await playwright.Firefox.LaunchAsync(options);
    }
}