using PlaywrightLibrary.Configuration;

namespace PlaywrightLibrary.Driver;

public interface IBrowserService
{
    public Task Start(TestSettings settings);
    public Task Quit();
}