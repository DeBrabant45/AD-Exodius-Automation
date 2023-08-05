using AD.Playwrightlib.Configuration;

namespace AD.Playwrightlib.Driver;
public interface IBrowserFactory
{
    Task<IBrowser> CreateBrowser(IPlaywright playwright, TestSettings settings);
}