namespace AD.Exodius.Pages.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class PageObjectMetaAttribute : Attribute
{
    public string Route { get; set; } = string.Empty;
    public string DomId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Type? Registry { get; set; }

    public PageObjectMetaAttribute() { }

    public PageObjectMetaAttribute(string route)
    {
        Route = route;
    }

    public PageObjectMetaAttribute(string route, string domId)
       : this(route)
    {
        DomId = domId;
    }

    public PageObjectMetaAttribute(string route, string domId, string pageName)
        : this(route, domId)
    {
        Name = pageName;
    }

    public PageObjectMetaAttribute(string route, string domId, string pageName, Type registry)
        : this(route, domId, pageName)
    {
        Registry = registry;
    }
}
