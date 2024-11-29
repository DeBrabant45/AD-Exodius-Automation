namespace AD.Exodius.Elements;

public class RadioButtonElement : BaseClickElement
{
    public RadioButtonElement(ILocator locator) 
        : base(locator)
    {

    }

    public override async Task Click()
    {
        if (await Locator.IsCheckedAsync())
            return;

        await Locator.ClickAsync();
    }

    public override async Task ForceClick()
    {
        if (await Locator.IsCheckedAsync())
            return;

        await Focus();
        await Locator.ClickAsync(new() { Force = true });
    }
}
