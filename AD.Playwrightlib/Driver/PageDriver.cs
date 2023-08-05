using AD.Playwrightlib.Locators;
using AD.Playwrightlib.Configuration;
using AD.Playwrightlib.Elements;
using AD.Playwrightlib.Locators;

namespace AD.Playwrightlib.Driver;

public class PageDriver : IDriver
{
    private readonly IPage _page;
    private readonly IBrowserFactory _browserFactory;
    private readonly IElementFactory _elementFactory;
    private readonly IPlaywright _playwright;

    public PageDriver(IBrowserFactory browserFactory, IElementFactory elementFactory, TestSettings settings)
    {
        _browserFactory = browserFactory;
        _elementFactory = elementFactory;
        _playwright = Playwright.CreateAsync().Result;
        _page = _browserFactory
            .CreateBrowser(_playwright, settings).Result
            .NewPageAsync().Result;
    }

    public async Task GoToUrl(string url) => await _page.GotoAsync(url);

    public async Task Quit() => await _page.CloseAsync();

    public TElement Find<TElement>(FindStrategy findStrategy) where TElement : IElement
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

    public async Task TakeScreenshotAsync(string fileName)
    {
        await _page.ScreenshotAsync(new PageScreenshotOptions() { Path = fileName, FullPage = true });
    }
}