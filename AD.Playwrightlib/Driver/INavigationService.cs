namespace AD.Playwrightlib.Driver;

public interface INavigationService
{
    public Task GoToUrl(string url);
    public Task TakeScreenshotAsync(string fileName);
}