using System.Text.RegularExpressions;
using AD.Exodius.Utility.Primitives;

namespace AD.Exodius.Elements;

public abstract class BaseElement : IElement
{
    protected readonly ILocator Locator;

    public BaseElement(ILocator locator)
    {
        Locator = locator;
    }

    public async Task<string> GetValue() => await Locator.InputValueAsync();

    public async Task<string> GetText() => await Locator.InnerTextAsync();

    public async Task<TPrimitive> GetTextAsType<TPrimitive>()
    {
        var rawText = await GetText();
        return rawText.ConvertToType<TPrimitive>();
    }

    public async Task<string> FindText()
    {
        if (!await IsVisible())
            return string.Empty;

        return await GetText();
    }

    public async Task<TPrimitive> FindTextAsType<TPrimitive>()
    {
        var rawText = await FindText();
        return rawText.ConvertToType<TPrimitive>();
    }

    public async Task<string> GetNumericText() => ExtractNumericValues(await GetText());

    public async Task<string> FindNumericText() => ExtractNumericValues(await FindText());

    public async Task<bool> IsEnabled() => await Locator.IsEnabledAsync();

    public async Task<bool> IsAttributePresent(string attribute, string value) => await Locator.GetAttributeAsync(attribute) == value;

    public async Task<bool> IsVisible() => await Locator.IsVisibleAsync();

    public async Task<bool> IsHidden() => await Locator.IsHiddenAsync();

    public async Task Focus() => await Locator.FocusAsync();

    public async Task Hover() => await Locator.HoverAsync();

    public async Task WaitUntilVisible(float timeout = 30f)
    {
        await WaitUntil(timeout, WaitForSelectorState.Visible);
    }

    public async Task WaitUntilHidden(float timeout = 30f)
    {
        await WaitUntil(timeout, WaitForSelectorState.Hidden);
    }

    private async Task WaitUntil(float timeout, WaitForSelectorState state)
    {
        await Locator.WaitForAsync(new() { State = state, Timeout = timeout * 1000 });
    }

    public async Task WaitUntilVisibleNoException(float timeout = 30f)
    {
        await WaitUntilNoException(WaitUntilVisible, timeout);
    }

    public async Task WaitUntilHiddenNoException(float timeout = 30f)
    {
        await WaitUntilNoException(WaitUntilHidden, timeout);
    }

    private async Task WaitUntilNoException(Func<float, Task> action, float timeout = 30f)
    {
        try
        {
            await action(timeout);
        }
        catch (TimeoutException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    protected string ExtractNumericValues(string text) => Regex.Match(text.Replace(",", ""), @"\d+|N/A").Value;
}