namespace AD.Exodius.Elements;

public abstract class BaseElement : IElement
{
    protected readonly ILocator Locator;

    public BaseElement(ILocator locator)
    {
        Locator = locator;
    }

    public async Task<string> Value() => await Locator.InputValueAsync();

    public async Task<string> Text() => await Locator.InnerTextAsync();

    public async Task<bool> IsEnabled() => await Locator.IsEnabledAsync();

    public async Task<bool> IsVisible() => await Locator.IsVisibleAsync();

    public async Task<bool> IsHidden() => await Locator.IsHiddenAsync();

    public async Task Focus() => await Locator.FocusAsync();    

    public async Task WaitUntilVisible(float timeout = 30f) => await Locator.WaitForAsync( new() { State = WaitForSelectorState.Visible, Timeout = timeout * 1000 });

    public async Task WaitUntilHidden(float timeout = 30f) => await Locator.WaitForAsync( new() { State = WaitForSelectorState.Hidden, Timeout = timeout * 1000 });
}