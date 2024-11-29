using AD.Exodius.Configurations;

namespace Mock.SwagLabs.Configurations.Models;

public class TestSettings
{
    public TestSettings(ApplicationSettings dashboardSettings, DriverSettings driverSettings)
    {
        ApplicationSettings = dashboardSettings;
        DriverSettings = driverSettings;
    }

    public ApplicationSettings ApplicationSettings { get; }

    public DriverSettings DriverSettings { get; }
}
