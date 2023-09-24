namespace AD.Exodius.Elements;

public class TextInputElement : BaseElement, IInputElement<string>
{
    public TextInputElement(ILocator webElement) : base(webElement)
    {

    }

    public async Task TypeInput(string input)
    {
        if (string.IsNullOrEmpty(input))
            return;

        await Locator.FillAsync(input);
    }
}
