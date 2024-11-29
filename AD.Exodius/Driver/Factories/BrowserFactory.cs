using AD.Exodius.Configurations;

namespace AD.Exodius.Driver.Factories;

public class BrowserFactory : IBrowserFactory
{
    public async Task<IBrowser> CreateBrowser(IPlaywright playwright, BrowserSettings settings)
    {
        return settings.Browser switch
        {
            Browser.Chrome => await CreateChromeDriver(playwright, settings),
            Browser.Firefox => await CreateFirefoxDriver(playwright, settings),
            Browser.Edge => await CreateEdgeDriver(playwright, settings),
            Browser.Chromium => await CreateChromiumDriver(playwright, settings),
            _ => await CreateChromiumDriver(playwright, settings)
        };
    }

    private async Task<IBrowser> CreateChromeDriver(IPlaywright playwright, BrowserSettings settings)
    {
        var options = CreateBrowserTypeOtions(settings);
        options.Channel = "chrome";

        return await playwright.Chromium.LaunchAsync(options);
    }

    private async Task<IBrowser> CreateFirefoxDriver(IPlaywright playwright, BrowserSettings settings)
    {
        var options = CreateBrowserTypeOtions(settings);
        options.Channel = "firefox";

        return await playwright.Firefox.LaunchAsync(options);
    }

    private async Task<IBrowser> CreateChromiumDriver(IPlaywright playwright, BrowserSettings settings)
    {
        var options = CreateBrowserTypeOtions(settings);
        options.Channel = "chromium";

        return await playwright.Chromium.LaunchAsync(options);
    }

    private async Task<IBrowser> CreateEdgeDriver(IPlaywright playwright, BrowserSettings settings)
    {
        var options = CreateBrowserTypeOtions(settings);
        options.Channel = "msedge";

        return await playwright.Chromium.LaunchAsync(options);
    }

    private BrowserTypeLaunchOptions CreateBrowserTypeOtions(BrowserSettings settings)
    {
        return new BrowserTypeLaunchOptions
        {
            Args = settings.Args,
            Timeout = ToMilliseconds(settings.Timeout),
            Headless = settings.Headless,
            SlowMo = settings.SlowMotion,
        };
    }

    private float? ToMilliseconds(float? seconds) => seconds * 1000;
}