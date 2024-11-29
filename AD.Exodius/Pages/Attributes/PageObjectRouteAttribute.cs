namespace AD.Exodius.Pages.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class PageObjectRouteAttribute : Attribute
{
    public string Route { get; }

    public PageObjectRouteAttribute(string route)
    {
        Route = route;
    }
}
