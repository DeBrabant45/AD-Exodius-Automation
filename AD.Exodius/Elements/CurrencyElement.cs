namespace AD.Exodius.Elements;

public class CurrencyElement : BaseInputElement<decimal>
{
    public CurrencyElement(ILocator locator) 
        : base(locator)
    {

    }

    public override async Task VisibilityTypeInput(decimal input)
    {
        if (!await IsVisible())
            return;

        await TypeInput(input);
    }

    public override async Task TypeInput(decimal input)
    {
        await Locator.FillAsync(input.ToString("0.00").Replace(".00", string.Empty));
    }
}
