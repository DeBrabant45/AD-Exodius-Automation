using AD.Exodius.Elements;

namespace AD.Exodius.Driver.Factories;

/// <summary>
/// Represents a factory for creating elements.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IElementFactory
{
    /// <summary>
    /// Creates an element of type <typeparamref name="TElement"/> based on the provided locator.
    /// </summary>
    /// <typeparam name="TElement">The type of element to create.</typeparam>
    /// <param name="locator">The locator used to identify the element.</param>
    /// <returns>The created element.</returns>
    TElement Create<TElement>(ILocator locator) where TElement : IElement;
}