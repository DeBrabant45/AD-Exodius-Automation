namespace AD.Playwrightlib.Elements;

public class ButtonElement : BaseElement, IClickable
{
    public ButtonElement(ILocator locator) : base(locator)
    {
    }

    public async Task Click() => await Locator.ClickAsync();
}