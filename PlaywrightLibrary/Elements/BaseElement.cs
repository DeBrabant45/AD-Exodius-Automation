using Microsoft.Playwright;

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