using Microsoft.Playwright;

namespace PlaywrightLibrary.Elements;

public class TextInputElement : BaseElement
{
    public TextInputElement(ILocator webElement) : base(webElement)
    {

    }

    public async Task TypeInput(string input) => await Locator.FillAsync(input);
}
