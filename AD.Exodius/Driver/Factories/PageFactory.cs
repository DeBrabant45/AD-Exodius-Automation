using AD.Exodius.Configurations;
using AD.Exodius.Helpers;

namespace AD.Exodius.Driver.Factories;

public class PageFactory : IPageFactory
{
    private readonly IBrowserFactory _browserFactory;
    private readonly DriverSettings _driverSettings;
    private readonly IPathResolver _pathResolver;

    public PageFactory(IBrowserFactory browserFactory, DriverSettings driverSettings, IPathResolver pathResolver)
    {
        _browserFactory = browserFactory;
        _driverSettings = driverSettings;
        _pathResolver = pathResolver;
    }

    public async Task<IPage> CreatePage(IBrowser browser)
    {
        var contextSettings = _driverSettings.ContextSettings;
        var storageStatePath = contextSettings.StorageStatePath;
        var isSessionStatePresent = _pathResolver.IsFilePresent(storageStatePath);
        var context = await browser.NewContextAsync(new()
        {
            StorageStatePath = isSessionStatePresent && contextSettings.UseSavedState ? storageStatePath : null,
            AcceptDownloads = _driverSettings.ContextSettings.AcceptDownloads,
            ViewportSize = _driverSettings.ContextSettings.ViewportSize,
        });

        return await context.NewPageAsync();
    }
}