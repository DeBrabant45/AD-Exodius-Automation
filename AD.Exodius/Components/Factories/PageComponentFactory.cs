using AD.Exodius.Drivers;
using AD.Exodius.Registries;

namespace AD.Exodius.Components.Factories;

public class PageComponentFactory 
{
    public static TPageComponent Create<TPageComponent>(IDriver driver, IPageComponentRegistry owner) where TPageComponent : IPageComponent
    {
        ArgumentNullException.ThrowIfNull(owner);
        ArgumentNullException.ThrowIfNull(driver);

        var instance = Activator.CreateInstance(typeof(TPageComponent), driver, owner)
            ?? throw new InvalidOperationException($"Failed to create an instance of {typeof(TPageComponent).Name}.");

        return (TPageComponent)instance;
    }
}
