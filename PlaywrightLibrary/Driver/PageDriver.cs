using PlaywrightLibrary.Configuration;
using PlaywrightLibrary.Elements;
using PlaywrightLibrary.Locators;

namespace PlaywrightLibrary.Driver;

public class PageDriver : IDriver
{
    private IPage _page;
    private BrowserFactory _browserFactory;
    private ElementFactory _elementFactory;

    public PageDriver()
    {
        _browserFactory = new BrowserFactory();
        _elementFactory = new ElementFactory();
    }

    public async Task Start(TestSettings settings)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await _browserFactory.CreateBrowser(playwright, settings);
        _page = await browser.NewPageAsync();
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
}