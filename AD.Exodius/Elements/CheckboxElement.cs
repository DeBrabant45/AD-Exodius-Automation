namespace AD.Exodius.Elements;

public class CheckboxElement : BaseElement
{
    public CheckboxElement(ILocator locator) : base(locator)
    {

    }

    /// <summary>
    /// <para>Performs a standard check.</para>
    /// <para>Action will throw an error if element is not present.</para>
    /// </summary>
    public async Task Check() => await Locator.CheckAsync();

    /// <summary>
    /// <para>Performs a standard uncheck.</para>
    /// <para>Action will throw an error if element is not present.</para>
    /// </summary>
    public async Task Uncheck() => await Locator.UncheckAsync();

    /// <summary>
    /// <para>Performs a standard uncheck if element is visible on the page.</para>
    /// <para>Action will be returned and no error will be thrown if element is not present.</para> 
    /// </summary>
    public async Task VisibilityUncheck()
    {
        if (!await IsVisible())
            return;

        await Uncheck();
    }

    /// <summary>
    /// <para>Performs a standard check if element is visible on the page.</para>
    /// <para>Action will be returned and no error will be thrown if element is not present.</para> 
    /// </summary>
    public async Task VisibilityCheck()
    {
        if (!await IsVisible())
            return;

        await Check();
    }

    /// <summary>
    /// <para>Performs a standard check/uncheck.</para>
    /// <para>Action will throw an error if element is not present.</para>
    /// </summary>
    public async Task SetChecked(bool enable)
    {
        if (enable)
        {
            await Check();
            return;
        }
        await Uncheck();
    }

    /// <summary>
    /// <para>Performs a standard check/uncheck if element is visible on the page.</para>
    /// <para>Action will be returned and no error will be thrown if element is not present.</para> 
    /// </summary>
    public async Task VisibilitySetChecked(bool enable)
    {
        if (!await IsVisible())
            return;

        await SetChecked(enable);
    }
}