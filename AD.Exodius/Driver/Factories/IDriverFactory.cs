using AD.Exodius.Configurations;

namespace AD.Exodius.Driver.Factories;

/// <summary>
/// Factory class responsible for encapsulating the creation of <see cref="IDriver"/> instances and its dependencies.
/// </summary>
public interface IDriverFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="IDriver"/> using the configured dependencies.
    /// </summary>
    /// <returns>A new instance of <see cref="IDriver"/>.</returns>
    public IDriver Create(DriverSettings driverSettings);
}