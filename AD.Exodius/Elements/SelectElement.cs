namespace AD.Exodius.Elements;

public class SelectElement : BaseElement
{
    public SelectElement(ILocator locator) 
        : base(locator)
    {

    }

    public async Task SelectValue(string value)
    {
        if (string.IsNullOrEmpty(value) || value == "None")
            return;

        await Locator.SelectOptionAsync(value);
    }

    public async Task SelectText(string text)
    {
        if (string.IsNullOrEmpty(text) || text == "None")
            return;

        await Locator.SelectOptionAsync(new[] { new SelectOptionValue() { Label = text } });
    }
}
