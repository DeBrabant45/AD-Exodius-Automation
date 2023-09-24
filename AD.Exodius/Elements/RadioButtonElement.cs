namespace AD.Exodius.Elements;

public class RadioButtonElement : BaseElement, IClickElement
{
    public RadioButtonElement(ILocator locator) 
        : base(locator)
    {

    }

    public async Task Click()
    {
        if (await Locator.IsCheckedAsync())
            return;

        await Locator.ClickAsync(new() { Force = true });
    }

    public async Task Click(bool shouldClick)
    {
        if (!shouldClick)
            return;

        await Click();
    }

    public async Task ForceClick()
    {
        if (await Locator.IsCheckedAsync())
            return;

        await Focus();
        await Locator.ClickAsync(new() { Force = true });
    }

    public async Task ForceClick(bool shouldForceClick)
    {
        if (!shouldForceClick)
            return;

        await ForceClick();
    }
}
