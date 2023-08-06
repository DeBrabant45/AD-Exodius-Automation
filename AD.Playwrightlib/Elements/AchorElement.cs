namespace AD.Playwrightlib.Elements;

public class AchorElement : BaseElement, IClickable
{
    public AchorElement(ILocator locator) : base(locator)
    {
    }

    public async Task Click() => await Locator.ClickAsync();

    public async Task Hover() => await Locator.HoverAsync();
}
