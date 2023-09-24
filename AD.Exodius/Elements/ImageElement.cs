namespace AD.Exodius.Elements;

public class ImageElement : BaseElement, IClickElement
{
    public ImageElement(ILocator locator) 
        : base(locator)
    {

    }

    public async Task<string> AltText() => await Locator.GetAttributeAsync("alt") ?? "";

    public async Task<string> Src() => await Locator.GetAttributeAsync("src") ?? "";

    public async Task DoubleClick() => await Locator.DblClickAsync();

    public async Task Click() => await Locator.ClickAsync();

    public async Task Click(int index) => await Locator.Nth(index).ClickAsync();

    public async Task ForceClick()
    {
        await Focus();
        await Locator.ClearAsync(new() { Force = true });
    }

    public async Task Click(bool shouldClick)
    {
        if (!shouldClick)
            return;

        await Click();
    }

    public async Task ForceClick(bool shouldClick)
    {
        if (!shouldClick)
            return;

        await ForceClick();
    }
}
