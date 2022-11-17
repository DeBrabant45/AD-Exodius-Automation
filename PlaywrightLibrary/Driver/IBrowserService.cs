using Microsoft.Playwright;

namespace PlaywrightLibrary.Driver;

public interface IBrowserService
{
    public Task Start(Browser browserType, BrowserTypeLaunchOptions options);
    public Task Quit();
}