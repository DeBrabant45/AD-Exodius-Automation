using AD.Exodius.Drivers;

namespace AD.Exodius.Navigators.Factories;

/// <summary>
/// Provides a factory for creating navigator instances.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface INavigatorFactory
{
    /// <summary>
    /// Creates an instance of the specified navigator type.
    /// </summary>
    /// <typeparam name="TNavigator">The type of navigator to create.</typeparam>
    /// <param name="driver">The driver instance to associate with the navigator.</param>
    /// <returns>An instance of the specified navigator type.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the navigator type cannot be created.
    /// </exception>
    public TNavigator Create<TNavigator>(IDriver driver) where TNavigator : INavigator;
}
