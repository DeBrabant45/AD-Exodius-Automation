using AD.Exodius.Configuration;

namespace AD.Exodius.Driver;

public interface IBrowserFactory
{
    Task<IBrowser> CreateBrowser(IPlaywright playwright, TestSettings settings);
}