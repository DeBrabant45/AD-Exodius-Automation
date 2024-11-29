namespace AD.Exodius.Elements;

public class ButtonElement : BaseClickElement
{
    public ButtonElement(ILocator locator) 
        : base(locator)
    {

    }

    public virtual async Task Click(int index) => await Locator.Nth(index).ClickAsync();
}