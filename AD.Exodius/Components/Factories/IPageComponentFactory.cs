namespace AD.Exodius.Components.Factories;

/// <summary>
/// Factory interface for creating page components.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IPageComponentFactory
{
    /// <summary>
    /// Creates an instance of the specified page component type.
    /// </summary>
    /// <typeparam name="TPageComponent">The type of the page component to create. Must implement <see cref="IPageComponent"/>.</typeparam>
    /// <returns>An instance of the specified page component type.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the specified component type does not exist in the factory.</exception>
    public TPageComponent Create<TPageComponent>() where TPageComponent : IPageComponent;
}
