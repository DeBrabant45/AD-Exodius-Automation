using AD.Exodius.Components;

namespace AD.Exodius.Registries;

/// <summary>
/// Represents a registry for managing page components, including adding, retrieving, and removing components.
/// Ensures only valid components (e.g., PageComponent) are added to the registry.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IPageComponentRegistry
{
    /// <summary>
    /// Adds a component to the registry. The component must be a subclass of <see cref="PageComponent"/>.
    /// </summary>
    /// <typeparam name="TPageComponent">The type of the component to add. Must be a subclass of <see cref="PageComponent"/>.</typeparam>
    /// <returns>The added component.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the component is not a valid type (i.e., not a subclass of <see cref="PageComponent"/>).</exception>
    TPageComponent AddComponent<TPageComponent>() where TPageComponent : PageComponent;

    /// <summary>
    /// Retrieves the first component of the specified type from the registry.
    /// </summary>
    /// <typeparam name="TPageComponent">The type of the component to retrieve.</typeparam>
    /// <returns>The component of the specified type.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no component of the specified type exists in the registry.</exception>
    TPageComponent GetComponent<TPageComponent>() where TPageComponent : IPageComponent;

    /// <summary>
    /// Retrieves all components of the specified type from the registry.
    /// </summary>
    /// <typeparam name="TPageComponent">The type of the components to retrieve.</typeparam>
    /// <returns>A list of components of the specified type.</returns>
    List<TPageComponent> GetComponents<TPageComponent>() where TPageComponent : IPageComponent;

    /// <summary>
    /// Initializes all lazy-loaded components in the registry. Components implementing <see cref="ILazyPageComponent"/> will be initialized.
    /// </summary>
    void InitializeLazyComponents();

    /// <summary>
    /// Removes a component of the specified type from the registry.
    /// </summary>
    /// <typeparam name="TPageComponent">The type of the component to remove.</typeparam>
    /// <exception cref="InvalidOperationException">Thrown if the component of the specified type is not found in the registry.</exception>
    void RemoveComponent<TPageComponent>() where TPageComponent : IPageComponent;
}
