using Microsoft.Playwright;
using PlaywrightLibrary.Elements;
using PlaywrightLibrary.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightLibrary.Driver;

public class PageDriver : IDriver
{
    private IPage _page;
    private BrowserFactory _browserFactory;
    private ElementFactory _elementFactory;

    public PageDriver()
    {
        _browserFactory= new BrowserFactory();
        _elementFactory= new ElementFactory();
    }

    public async Task Start(Browser browserType, BrowserTypeLaunchOptions options)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await _browserFactory.CreateBrowser(playwright, browserType, options);
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
}