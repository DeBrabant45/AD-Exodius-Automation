namespace AD.Exodius.Elements;

public class AnchorElement : BaseElement, IClickElement
{
    public AnchorElement(ILocator locator) 
        : base(locator)
    {

    }

    public async Task Hover() => await Locator.HoverAsync();

    public async Task Click() => await Locator.ClickAsync();

    public async Task Click(bool shouldClick)
    {
        if (!shouldClick)
            return;

        await Click();
    }

    public async Task ForceClick()
    {
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
