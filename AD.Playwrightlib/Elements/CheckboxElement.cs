namespace AD.Playwrightlib.Elements;

public class CheckboxElement : BaseElement
{
    public CheckboxElement(ILocator locator) : base(locator)
    {

    }

    public async Task EnableCheckBox() => await Locator.CheckAsync();

    public async Task DisableCheckBox() => await Locator.UncheckAsync();
}