namespace AD.Exodius.Elements;

public interface IElement
{
    public Task Focus();
    public Task<string> Text();
    public Task<string> Value();
    public Task<bool> IsEnabled();
    public Task<bool> IsVisible();
    public Task<bool> IsHidden();
    public Task WaitUntilVisible(float timeout = 30f);
    public Task WaitUntilHidden(float timeout = 30f);
}
