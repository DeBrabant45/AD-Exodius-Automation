namespace AD.Exodius.Elements;

public interface IClickElement
{
    public Task Click();
    public Task Click(bool shouldClick);
    public Task ForceClick();
    public Task ForceClick(bool shouldForceClick);
    public Task NoHoverClick();
}
