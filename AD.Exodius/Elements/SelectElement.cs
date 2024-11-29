﻿namespace AD.Exodius.Elements;

public class SelectElement : BaseElement
{
    public SelectElement(ILocator locator) 
        : base(locator)
    {

    }

    /// <summary>
    ///  <para>Performs a standard select of the element if the parameter is not null, empty or None.</para>
    ///  <para>Action will throw an error if element is not present.</para>
    /// </summary>
    public async Task SelectValue(string value)
    {
        if (string.IsNullOrEmpty(value) || value == "None")
            return;

        await Locator.SelectOptionAsync(value);
    }

    /// <summary>
    /// <para>Performs a standard select of the element if the parameter is not null, empty, None and is visible on the page.</para>
    /// <para>Action will be returned and no error will be thrown if element is not present.</para>
    /// </summary>
    public async Task VisibilitySelectValue(string value)
    {
        if (!await IsVisible())
            return;

        await SelectValue(value);
    }

    /// <summary>
    ///  <para>Performs a standard select of the element if the parameter is not null, empty or None.</para>
    ///  <para>Action will throw an error if element is not present.</para>
    /// </summary>
    public async Task SelectText(string text)
    {
        if (string.IsNullOrEmpty(text) || text == "None")
            return;

        await Locator.SelectOptionAsync(new[] { new SelectOptionValue() { Label = text } });
    }

    /// <summary>
    /// <para>Performs a standard select of the element if the parameter is not null, empty, None and is visible on the page.</para>
    /// <para>Action will be returned and no error will be thrown if element is not present.</para>
    /// </summary>
    public async Task VisibilitySelectText(string text)
    {
        if (!await IsVisible())
            return;

        await SelectText(text);
    }
}
