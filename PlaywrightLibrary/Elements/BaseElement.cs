using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightLibrary.Elements;

public class BaseElement : IElement
{
    protected ILocator Locator;

    public BaseElement(ILocator webElement)
    {
        Locator = webElement;
    }

    public async Task<string> Value() => await Locator.InputValueAsync();
    public async Task<string> Text() => await Locator.InnerTextAsync();
}