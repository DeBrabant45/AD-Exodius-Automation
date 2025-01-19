using AD.Exodius.Configurations;
using AD.Exodius.Helpers;

namespace AD.Exodius.Drivers.Factories;

public class DriverFactory : IDriverFactory
{
    public IDriver Create(DriverSettings driverSettings)
    {
        var browserFactory = new BrowserFactory();
        var pathResolver = new PathResolver();
        var pageFactory = new PageFactory(browserFactory, driverSettings, pathResolver);
        var locatorStrategyFactory = new LocatorStrategyFactory();
        var elementFactory = new ElementFactory();
        var networkFactory = new NetworkResponseFactory();

        return new PageDriver(
            pageFactory,
            locatorStrategyFactory,
            browserFactory,
            elementFactory,
            networkFactory,
            driverSettings,
            pathResolver);
    }
}
