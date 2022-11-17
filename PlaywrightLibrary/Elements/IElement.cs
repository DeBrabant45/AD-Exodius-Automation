namespace PlaywrightLibrary.Elements;

public interface IElement
{
    public Task<string> Text();
    public Task<string> Value();
}
