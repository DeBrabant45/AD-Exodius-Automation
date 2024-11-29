using AD.Exodius.Components;
using AD.Exodius.Driver;

namespace AD.Exodius.Pages;

public class PageObject : IPageObject
{
    protected readonly IDriver Driver;
    private readonly HashSet<IPageComponent> _components = [];

    public PageObject(IDriver driver)
    {
        Driver = driver;
    }

    public void AddComponent(IPageComponent component)
    {
        _components.Add(component);
    }

    public void AddComponents(IEnumerable<IPageComponent> components)
    {
        foreach (var component in components)
        {
            AddComponent(component);
        }
    }

    public virtual TPageComponent GetComponent<TPageComponent>() where TPageComponent : IPageComponent
    {
        ValidateComponentType<TPageComponent>();

        return _components.OfType<TPageComponent>().FirstOrDefault()
            ?? throw new InvalidOperationException($"{typeof(TPageComponent).Name} does not exist in {GetType().Name} lists of components!");
    }

    public virtual List<TPageComponent> GetComponents<TPageComponent>() where TPageComponent : IPageComponent
    {
        ValidateComponentType<TPageComponent>();

        return _components.OfType<TPageComponent>().ToList();
    }

    private void ValidateComponentType<TPageComponent>() where TPageComponent : IPageComponent
    {
        Type pageComponent = typeof(TPageComponent);
        if (typeof(IPageComponent).IsAssignableFrom(pageComponent))
            return;

        throw new InvalidOperationException($"{pageComponent.Name} must derive from IPageComponent!");
    }
}
