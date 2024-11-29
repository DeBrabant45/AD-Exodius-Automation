namespace AD.Exodius.Elements;

public class ImageElement : BaseClickElement
{
    public ImageElement(ILocator locator) 
        : base(locator)
    {

    }

    public async Task<string> FindAltText() => await Locator.GetAttributeAsync("alt") ?? "";

    public async Task<string> FindSrc() => await Locator.GetAttributeAsync("src") ?? "";

    public async Task<bool> IsDataIconPresent(string iconName) => await IsAttributePresent("data-icon", iconName);

    public virtual async Task Click(int index) => await Locator.Nth(index).ClickAsync();
}
