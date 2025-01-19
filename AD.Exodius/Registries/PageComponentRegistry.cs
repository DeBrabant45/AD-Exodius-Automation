using AD.Exodius.Components;
using AD.Exodius.Components.Factories;
using AD.Exodius.Drivers;

namespace AD.Exodius.Registries;

public class PageComponentRegistry : IPageComponentRegistry
{
    protected readonly IDriver Driver;
    private readonly HashSet<IPageComponent> _components;

    public PageComponentRegistry(IDriver driver)
    {
        Driver = driver;
        _components = [];
    }

    public TPageComponent AddComponent<TPageComponent>() where TPageComponent : PageComponent
    {
        var component = PageComponentFactory.Create<TPageComponent>(Driver, this);
        _components.Add(component);

        return component;
    }

    public TPageComponent GetComponent<TPageComponent>() where TPageComponent : IPageComponent
    {
        return _components.OfType<TPageComponent>().FirstOrDefault()
            ?? throw new InvalidOperationException($"{typeof(TPageComponent).Name} does not exist in {GetType().Name} lists of components!");
    }

    public List<TPageComponent> GetComponents<TPageComponent>() where TPageComponent : IPageComponent
    {
        return _components.OfType<TPageComponent>().ToList();
    }

    public void InitializeLazyComponents()
    {
        GetComponents<ILazyPageComponent>()
            .ToList()
            .ForEach(lazyComponent => lazyComponent.Initialize());
    }

    public void RemoveComponent<TPageComponent>() where TPageComponent : IPageComponent
    {
        _components.Remove(GetComponent<TPageComponent>());
    }
}
