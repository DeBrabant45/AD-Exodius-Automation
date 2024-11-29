using AD.Exodius.Pages.Helpers;

namespace AD.Exodius.Pages.Factories;

public class AttributePageObjectFactory : IAttributePageObjectFactory
{
    private readonly IEnumerable<IPageObject> _pages;
    private readonly IPageObjectAttributeCache _attributeCache;

    public AttributePageObjectFactory(IEnumerable<IPageObject> pages,
        IPageObjectAttributeCache attributeCache)
    {
        if (pages == null || !pages.Any())
            throw new ArgumentException("No pages provided or found in the provided collection.");

        _pages = pages;
        _attributeCache = attributeCache;
        _attributeCache.PopulateCache(_pages);
    }

    public TPage Create<TPage, TAttribute, TValue>(TValue value)
        where TPage : IPageObject
        where TAttribute : Attribute
    {
        var pageType = typeof(TPage);
        var attributeType = typeof(TAttribute);
        var attribute = _attributeCache.GetAttributeValues(pageType, attributeType);

        if (attribute == null)
            throw new InvalidOperationException($"No attributes of type {attributeType.Name} found for page type {pageType.Name}.");

        return _pages.OfType<TPage>().FirstOrDefault(x => MatchValue(attribute, value))
            ?? throw new InvalidOperationException($"No page of type {pageType.Name} found with attribute {attributeType.Name} matching value '{value}'.");
    }

    private bool MatchValue<TValue>(Dictionary<string, object> attribute, TValue value)
    {
        return attribute.Values.Any(v => v?.Equals(value) == true);
    }
}
