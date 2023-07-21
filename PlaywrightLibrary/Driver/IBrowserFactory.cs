using PlaywrightLibrary.Configuration;

namespace PlaywrightLibrary.Driver;
public interface IBrowserFactory
{
    Task<IBrowser> CreateBrowser(IPlaywright playwright, TestSettings settings);
}