namespace AD.Exodius.Elements;

public class TextInputElement : BaseInputElement<string>
{
    public TextInputElement(ILocator webElement) : base(webElement)
    {

    }

    public override async Task TypeInput(string input)
    {
        if (string.IsNullOrEmpty(input))
            return;

        await Locator.FillAsync(input);
    }

    public override async Task VisibilityTypeInput(string input)
    {
        if (!await IsVisible())
            return;

        await TypeInput(input);
    }
}
