namespace AD.Playwrightlib.Elements;

public class CurrencyElement : BaseElement
{
    public CurrencyElement(ILocator locator) : base(locator)
    {
    }

    public async Task TypeInput(decimal input)
    {
        await Locator.FillAsync(input.ToString("0.00").Replace(".00", String.Empty));
    }
}
