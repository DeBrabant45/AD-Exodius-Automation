namespace AD.Playwrightlib.Elements;

public class DropdownElement : BaseElement
{
    public DropdownElement(ILocator locator) 
        : base(locator)
    {
    }

    public async Task SelectValue(string value)
    {
        await Locator.SelectOptionAsync(value);
    }
}
