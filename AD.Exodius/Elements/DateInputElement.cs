namespace AD.Exodius.Elements;

public class DateInputElement : BaseInputElement<DateOnly>
{
    public DateInputElement(ILocator locator) 
        : base(locator)
    {

    }

    /// <summary>
    /// <para>Performs a standard input of the element if the parameter does not contain a date of 01,01,0001, and is visible on the page.</para>
    /// <para>Action will be returned and no error will be thrown if element is not present.</para>
    /// </summary>
    public override async Task VisibilityTypeInput(DateOnly input)
    {
        if (!await IsVisible())
            return;

        await TypeInput(input);
    }

    /// <summary>
    /// <para>Performs a standard input of the element if the parameter does not contain a date of 01,01,0001</para>
    /// <para>Action will throw an error if element is not present.</para>
    /// </summary>
    public override async Task TypeInput(DateOnly date)
    {
        if (date == DateOnly.MinValue)
            return;

        await Locator.FillAsync(date.ToShortDateString());
    }
}
