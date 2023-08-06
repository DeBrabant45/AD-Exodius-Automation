namespace AD.Playwrightlib.Elements;

public abstract class BaseElement : IElement
{
    protected ILocator Locator;

    public BaseElement(ILocator locator)
    {
        Locator = locator;
    }

    public async Task<string> Value() => await Locator.InputValueAsync();

    public async Task<string> Text() => await Locator.InnerTextAsync();

    public async Task<bool> IsEnabled() => await Locator.IsEnabledAsync();

    public async Task<bool> IsVisible() => await Locator.IsVisibleAsync();

    public async Task<bool> IsHidden() => await Locator.IsHiddenAsync();
}