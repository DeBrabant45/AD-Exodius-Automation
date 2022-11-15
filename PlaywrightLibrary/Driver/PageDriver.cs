using Microsoft.Playwright;
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

    public PageDriver()
    {
        _browserFactory= new BrowserFactory();
    }

    public async Task Start(Browser browserType, BrowserTypeLaunchOptions options)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await _browserFactory.CreateBrowser(playwright, browserType, options);
        _page = await browser.NewPageAsync();
    }

    public async Task GoToUrl(string url) => await _page.GotoAsync(url);

    public async Task Quit() => await _page.CloseAsync();
}