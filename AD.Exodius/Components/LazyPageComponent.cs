using AD.Exodius.Drivers;
using AD.Exodius.Registries;

namespace AD.Exodius.Components;

public abstract class LazyPageComponent : PageComponent, ILazyPageComponent
{
    protected LazyPageComponent(
        IDriver driver,
        IPageComponentRegistry owner) 
        : base(driver, owner)
    {

    }

    public abstract void Initialize();
}
