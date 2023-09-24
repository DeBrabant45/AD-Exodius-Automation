namespace AD.Exodius.Elements;

public class CheckboxElement : BaseElement
{
    public CheckboxElement(ILocator locator) : base(locator)
    {

    }

    public async Task Check() => await Locator.CheckAsync();

    public async Task Uncheck() => await Locator.UncheckAsync();

    public async Task SetChecked(bool enable)
    {
        if (enable)
        {
            await Check();
            return;
        }
        await Uncheck();
    }
}