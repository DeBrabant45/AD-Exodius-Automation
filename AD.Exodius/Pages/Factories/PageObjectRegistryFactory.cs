using AD.Exodius.Pages.Extensions;
using AD.Exodius.Pages.Registries;

namespace AD.Exodius.Pages.Factories;

public class PageObjectRegistryFactory : IPageObjectRegistryFactory
{
    public IPageObjectRegistry? Create<TPageObject>(TPageObject page) where TPageObject : IPageObject
    {
        var hasMeta = page.TryGetPageObjectMeta(out var meta);
        var registryType = meta?.Registry;

        if (!hasMeta || registryType is null)
            return null;

        if (!typeof(IPageObjectRegistry).IsAssignableFrom(registryType))
            throw new ArgumentException($"{registryType.Name} must implement IPageObjectRegistry.");

        if (registryType.GetConstructor(Type.EmptyTypes) == null)
            throw new InvalidOperationException($"{registryType.Name} must have a parameterless constructor.");

        var instance = Activator.CreateInstance(registryType)
            ?? throw new InvalidOperationException($"Could not create instance of {registryType.Name}.");

        return (IPageObjectRegistry)instance;
    }
}
