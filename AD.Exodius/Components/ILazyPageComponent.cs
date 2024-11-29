namespace AD.Exodius.Components;

/// <summary>
/// Represents a page component that supports lazy initialization.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface ILazyPageComponent : IPageComponent
{
    /// <summary>
    /// Initializes the page component.
    /// This method should be called to prepare the component for use, 
    /// typically after it has been lazily instantiated or loaded.
    /// </summary>
    public void Initialize();
}
