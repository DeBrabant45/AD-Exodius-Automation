namespace AD.Exodius.Pages.Factories;

/// <summary>
/// Represents a factory responsible for creating instances of page objects
/// based on attributes and associated values.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IAttributePageObjectFactory
{
    /// <summary>
    /// Creates an instance of a page object based on the specified attribute and value.
    /// </summary>
    /// <typeparam name="TPage">The type of the page object to create.</typeparam>
    /// <typeparam name="TAttribute">The attribute type that is associated with the page object.</typeparam>
    /// <typeparam name="TValue">The type of the value used during page object creation.</typeparam>
    /// <param name="value">The value to be passed when creating the page object.</param>
    /// <returns>An instance of the page object <typeparamref name="TPage"/>.</returns>
    public TPage Create<TPage, TAttribute, TValue>(TValue value) where TPage : IPageObject where TAttribute : Attribute;
}