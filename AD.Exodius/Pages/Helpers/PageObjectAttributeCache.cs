namespace AD.Exodius.Pages.Helpers;

public class PageObjectAttributeCache : IPageObjectAttributeCache
{
    private readonly Dictionary<Type, Dictionary<Type, Dictionary<string, object>>> _attributeCache = [];

    public void PopulateCache(IEnumerable<IPageObject> pages)
    {
        foreach (var page in pages)
        {
            var pageType = page.GetType();
            var attributes = pageType.GetCustomAttributes(true);

            foreach (var attribute in attributes)
            {
                var attributeType = attribute.GetType();

                if (!_attributeCache.ContainsKey(pageType))
                {
                    _attributeCache[pageType] = [];
                }

                if (!_attributeCache[pageType].ContainsKey(attributeType))
                {
                    _attributeCache[pageType][attributeType] = [];
                }

                CacheAttributeProperties(attribute, attributeType, pageType);
                CacheAttributeFields(attribute, attributeType, pageType);
            }
        }
    }

    private void CacheAttributeProperties(object attribute, Type attributeType, Type pageType)
    {
        var properties = attributeType.GetProperties();
        foreach (var prop in properties)
        {
            if (prop.CanRead)
            {
                var value = prop.GetValue(attribute);

                _attributeCache[pageType][attributeType][prop.Name] = value
                    ?? throw new ArgumentException($"Property '{prop.Name}' of attribute '{attributeType.Name}' cannot be null.");
            }
        }
    }

    private void CacheAttributeFields(object attribute, Type attributeType, Type pageType)
    {
        var fields = attributeType.GetFields();
        foreach (var field in fields)
        {
            var value = field.GetValue(attribute);

            _attributeCache[pageType][attributeType][field.Name] = value
                ?? throw new ArgumentException($"Field '{field.Name}' of attribute '{attributeType.Name}' cannot be null.");
        }
    }

    public Dictionary<string, object>? GetAttributeValues(Type pageType, Type attributeType)
    {
        return (_attributeCache.TryGetValue(pageType, out var attributeDict) 
            && attributeDict.TryGetValue(attributeType, out var attributes)) ? attributes : null;
    }
}
