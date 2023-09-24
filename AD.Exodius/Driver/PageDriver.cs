using AD.Exodius.Locators;
using AD.Exodius.Configuration;
using AD.Exodius.Elements;

namespace AD.Exodius.Driver;

public class PageDriver : IDriver
{
    private IPage _page;
    private readonly IBrowserFactory _browserFactory;
    private readonly IElementFactory _elementFactory;
    private readonly TestSettings _testSettings;

    public PageDriver(IBrowserFactory browserFactory, IElementFactory elementFactory, TestSettings settings)
    {
        _browserFactory = browserFactory;
        _elementFactory = elementFactory;
        _testSettings = settings;
        var playwright = Playwright.CreateAsync().Result;
        _page = _browserFactory
            .CreateBrowser(playwright, settings).Result
            .NewContextAsync( new()
            {
                StorageStatePath = IsSessionStatePresent() && settings.UseSavedState ? _testSettings.StorageStatePath : null,
                AcceptDownloads = settings.AcceptDownloads,
                BaseURL = settings.ApplicationUrl,
                ViewportSize = settings.ViewportSize,
            }).Result
            .NewPageAsync().Result;
    }

    public async Task Refresh() => await _page.ReloadAsync();

    public async Task GoToUrl(string url) => await _page.GotoAsync(url);

    public async Task Quit() => await _page.CloseAsync();

    public async Task ClosePage(int index) => await _page.Context.Pages[index].CloseAsync();

    public async Task WaitForDomContentLoaded() => await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

    public async Task WatiForTimeout(float timeout) => await _page.WaitForTimeoutAsync(timeout * 1000);

    public async Task StoreSessionState() => await _page.Context.StorageStateAsync(new() { Path = _testSettings.StorageStatePath });

    public bool IsSessionStatePresent() => File.Exists(_testSettings.StorageStatePath);

    public async Task TakeScreenshotAsync(string fileName) => await _page.ScreenshotAsync(new() { Path = fileName, FullPage = true });

    public async Task SwitchToNewPage(IClickElement clickableElement) => _page = await _page.Context.RunAndWaitForPageAsync(clickableElement.Click);

    public void SwitchToPage(int index) => _page = _page.Context.Pages[index];

    public void SwitchToDefaultPage() => _page = _page.Context.Pages.First();

    private TElement Find<TElement>(FindStrategy findStrategy) where TElement : IElement
    {
        var nativeElement = _page.Locator(findStrategy.Convert());
        return _elementFactory.Create<TElement>(nativeElement);
    }

    public TElement FindElementById<TElement>(string id) where TElement : IElement
    {
        return Find<TElement>(new IdFindStrategy(id));
    }

    public TElement FindElementByCss<TElement>(string css) where TElement : IElement
    {
        return Find<TElement>(new CssSelectorFindStrategy(css));
    }    
    
    public TElement FindElementByXPath<TElement>(string xpath) where TElement : IElement
    {
        return Find<TElement>(new XPathFindStrategy(xpath));
    }

    public TElement FindElementByTestData<TElement>(string testdata) where TElement : IElement
    {
        return Find<TElement>(new TestDataFindStrategy(testdata));
    }

    public TElement FindElementByText<TElement>(string text) where TElement : IElement
    {
        return Find<TElement>(new TextFindStrategy(text));
    }

    public TElement FindElementByPlaceholder<TElement>(string placeholder) where TElement : IElement
    {
        return Find<TElement>(new PlaceholderFindStrategy(placeholder));
    }

    private async Task<List<TElement>> FindAll<TElement>(FindStrategy findStrategy) where TElement : IElement
    {
        var nativeElements = await _page.Locator(findStrategy.Convert()).AllAsync();
        return nativeElements.Select(_elementFactory.Create<TElement>).ToList();
    }

    public List<TElement> FindAllElementsById<TElement>(string id) where TElement : IElement
    {
        return Task.Run(async () => await FindAll<TElement>(new IdFindStrategy(id))).Result;
    }
    
    public List<TElement> FindAllElementsByXPath<TElement>(string xpath) where TElement : IElement
    {
        return Task.Run(async () => await FindAll<TElement>(new XPathFindStrategy(xpath))).Result;
    }
    
    public List<TElement> FindAllElementsByText<TElement>(string text) where TElement : IElement
    {
        return Task.Run(async () => await FindAll<TElement>(new TextFindStrategy(text))).Result;
    }

    public List<TElement> FindAllElementsByCss<TElement>(string css) where TElement : IElement
    {
        return Task.Run(async () => await FindAll<TElement>(new CssSelectorFindStrategy(css))).Result;
    }

    public List<TElement> FindAllElementsByTestData<TElement>(string testdata) where TElement : IElement
    {
        return Task.Run(async () =>  await FindAll<TElement>(new TestDataFindStrategy(testdata))).Result;
    }
}