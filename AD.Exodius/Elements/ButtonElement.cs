namespace AD.Exodius.Elements;

public class ButtonElement : BaseElement, IClickElement
{
    public ButtonElement(ILocator locator) : base(locator)
    {
    }

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