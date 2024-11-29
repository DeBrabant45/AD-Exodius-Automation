namespace AD.Exodius.Pages.Helpers;

public interface IPageObjectAttributeCache
{
    public void PopulateCache(IEnumerable<IPageObject> pages);
    public Dictionary<string, object>? GetAttributeValues(Type pageType, Type attributeType);
}
