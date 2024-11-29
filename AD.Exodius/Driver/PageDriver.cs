using Serilog;
using AD.Exodius.Configurations;
using AD.Exodius.Driver.Factories;
using AD.Exodius.Elements;
using AD.Exodius.Helpers;
using AD.Exodius.Locators;
using AD.Exodius.Networks;

namespace AD.Exodius.Driver;

public class PageDriver : IDriver, IDisposable
{
    private IPage _page;
    private IBrowser _browser;
    private IPlaywright _playwright;
    private readonly IPageFactory _pageFactory;
    private readonly ILocatorStrategyFactory _locatorStrategyFactory;
    private readonly IBrowserFactory _browserFactory;
    private readonly IElementFactory _elementFactory;
    private readonly INetworkResponseFactory _networkResponseFactory;
    private readonly DriverSettings _driverSettings;
    private readonly IPathResolver _pathResolver;

    public PageDriver(
        IPageFactory pageFactory,
        ILocatorStrategyFactory locatorStrategyFactory,
        IBrowserFactory browserFactory,
        IElementFactory elementFactory, 
        INetworkResponseFactory responseFactory, 
        DriverSettings settings,
        IPathResolver pathResolver)
    {
        _pageFactory = pageFactory;
        _locatorStrategyFactory = locatorStrategyFactory;
        _browserFactory = browserFactory;
        _elementFactory = elementFactory;
        _networkResponseFactory = responseFactory;
        _driverSettings = settings;
        _pathResolver = pathResolver;
    }

    public async Task OpenPage()
    {
        await StartNodeJsRuntime();
        _browser = await _browserFactory.CreateBrowser(_playwright, _driverSettings.BrowserSettings);
        _page = await _pageFactory.CreatePage(_browser);
    }

    private async Task StartNodeJsRuntime()
    {
        if (_playwright != null)
            return;

        _playwright = await Playwright.CreateAsync();
    }

    public async Task GoToUrl(string url)
    {
        await _page.GotoAsync(url);
    }

    public async Task ClosePage()
    {
        await _page.Context.CloseAsync();
        await _page.CloseAsync();
        foreach (var context in _browser.Contexts)
        {
            await context.CloseAsync();
        }
        await _browser.CloseAsync();
        await _browser.DisposeAsync();
    }

    public async Task Refresh()
    {
        await _page.ReloadAsync();
    }

    public string CurrentUrl()
    {
        return _page.Url;
    }

    public string BuildUrlWithRoute(string route)
    {
        var currentUrl = CurrentUrl();
        var baseUrl = UrlBuilder.GetBaseUrl(currentUrl);
        var newUrl = UrlBuilder.AppendRoute(baseUrl, route);

        return newUrl;
    }

    public async Task ClosePage(int index)
    {
        await _page.Context.Pages[index].CloseAsync();
    }

    public async Task WaitForDomContentLoaded()
    {
        await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }

    public async Task WaitForNavigation(IClickElement clickableElement)
    {
        await _page.RunAndWaitForNavigationAsync(clickableElement.Click);
    }

    public async Task WaitForTimeout(float timeout)
    {
        await _page.WaitForTimeoutAsync(timeout);
    }

    public async Task SaveCookieSession()
    {
        await _page.Context.StorageStateAsync(new()
        {
            Path = _driverSettings.ContextSettings.StorageStatePath
        });
    }

    public async Task SwitchToNewPage(IClickElement clickableElement)
    {
        _page = await _page.Context.RunAndWaitForPageAsync(clickableElement.Click);
    }

    public void SwitchToPage(int index)
    {
        _page = _page.Context.Pages[index]; 
    }

    public void SwitchToDefaultPage()
    {
        _page = _page.Context.Pages.First();
    }

    public async Task StartDiagnostics(string testName)
    {
        await StartTrace(testName);
    }

    private async Task StartTrace(string testName)
    {
        var traceSettings = _driverSettings.TraceSettings;

        if (!traceSettings.IsTraceEnabled)
            return;

        await _page.Context.Tracing.StartAsync(new()
        {
            Title = testName,
            Screenshots = traceSettings.Screenshots,
            Snapshots = traceSettings.Snapshots,
            Sources = traceSettings.Sources,
            Name = testName,
        });
    }

    public async Task StopDiagnostics(TestResults testResults)
    {
        var captureType = _driverSettings.TraceSettings.CaptureType;

        if ((testResults.HasTestFailed && captureType == CaptureType.Failure)
            || (!testResults.HasTestFailed && captureType == CaptureType.Success)
            || captureType == CaptureType.All)
        {
            var path = _pathResolver.GeneratePath(testResults.FolderPaths);
            await StopTrace(path);
            await TakeScreenshot(path);
            AddTestLogs(testResults, path);
        }
    }

    private void AddTestLogs(TestResults testResults, string path)
    {
        var textPath = _pathResolver.Append(path, "testlogs.txt");
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(textPath, outputTemplate: "[{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        testResults.TestParameters.ForEach(parameter =>
        {
            var parameterName = parameter.Item1;
            var parameterValues = parameter.Item2;
            if (parameterValues.Count <= 0)
            {
                Log.Information($"Parameter: {parameterName}");
                return;
            }

            Log.Information("Parameter: {ParameterName}: {@ParameterValues}", parameterName, parameterValues);
        });

        if (!testResults.HasTestFailed)
            return;

        Log.Error($"Expected Results: {testResults.ExpectedResults}");
        Log.Error($"Stack Trace Results: {testResults.StackTrace}");
        Log.CloseAndFlush();
    }

    private async Task StopTrace(string path)
    {
        if (!_driverSettings.TraceSettings.IsTraceEnabled)
            return;

        try
        {
            var tracePath = _pathResolver.Append(path, "trace.zip");
            await _page.Context.Tracing.StopAsync(new()
            {
                Path = tracePath,
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error stopping trace: {ex.Message}", ex);
        }
    }

    private async Task TakeScreenshot(string path)
    {
        try
        {
            var screenshotPath = _pathResolver.Append(path, "screenshot.png");
            await _page.ScreenshotAsync(new()
            {
                Path = screenshotPath,
                FullPage = true,
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error taking screenshot: {ex.Message}", ex);
        }
    }

    public async Task CancelRequest(string url)
    {
        await _page.RouteAsync(url, async (route) =>
        {
            await route.AbortAsync();
        });
    }

    public async Task AddToken(string tokenAccess, string baseUrl)
    {
        await _page.Context.AddCookiesAsync(new[]
        {
            new Cookie
            {
                Name = "token",
                Value = tokenAccess,
                Domain = new Uri(baseUrl).Host, 
                Path = "/",
                Secure = true,
                HttpOnly = true
            }
        });
    }

    public TElement FindElement<TLocatorStrategy, TElement>(params string[] values)
        where TLocatorStrategy : LocatorStrategy
        where TElement : IElement
    {
        var locatorStrategy = _locatorStrategyFactory.Create<TLocatorStrategy>(values);
        var nativeElement = _page.Locator(locatorStrategy.Convert());

        return _elementFactory.Create<TElement>(nativeElement);
    }

    public async Task<List<TElement>> FindAllElements<TLocatorStrategy, TElement>(params string[] values)
        where TLocatorStrategy : LocatorStrategy
        where TElement : IElement
    {
        var locatorStrategy = _locatorStrategyFactory.Create<TLocatorStrategy>(values);
        var nativeElements = await _page.Locator(locatorStrategy.Convert()).AllAsync();

        return nativeElements.Select(_elementFactory.Create<TElement>).ToList();
    }

    public TNetworkResponse FindNetworkResponse<TNetworkResponse>(string networkUrl) where TNetworkResponse : INetworkResponse
    {
        var response = _page.WaitForResponseAsync(n => n.Url.Contains(networkUrl));
        return _networkResponseFactory.Create<TNetworkResponse>(response);
    }

    public List<TNetworkResponse> FindAllNetworkResponses<TNetworkResponse>(string networkUrl) where TNetworkResponse : INetworkResponse
    {
        var responses = new List<TNetworkResponse>();
        _page.Response += (_, response) =>
        {
            if (response.Url.Contains(networkUrl))
            {
                responses.Add(_networkResponseFactory.Create<TNetworkResponse>(Task.FromResult(response)));
            }
        };
        _page.Response -= (_, response) => { };

        return responses;
    }

    public void Dispose()
    {
        _playwright.Dispose();
    }
}
