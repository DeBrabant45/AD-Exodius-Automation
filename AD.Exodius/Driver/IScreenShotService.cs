namespace AD.Exodius.Driver;

public interface IScreenShotService
{
    public Task TakeScreenshotAsync(string fileName);
}
