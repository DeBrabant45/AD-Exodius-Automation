namespace AD.Exodius.Elements;

public class DateInputElement : BaseElement, IInputElement<DateTime>
{
    public DateInputElement(ILocator locator) : base(locator)
    {
    }

    public async Task TypeInput(DateTime date)
    {
        await Locator.FillAsync(date.ToShortDateString());
    }
}
