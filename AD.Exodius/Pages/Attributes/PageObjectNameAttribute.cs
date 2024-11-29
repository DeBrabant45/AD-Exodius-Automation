namespace AD.Exodius.Pages.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class PageObjectNameAttribute : Attribute
{
    public string Name { get; }

    public PageObjectNameAttribute(string name)
    {
        Name = name;
    }
}
