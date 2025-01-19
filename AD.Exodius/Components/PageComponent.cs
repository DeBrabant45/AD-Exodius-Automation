using AD.Exodius.Drivers;
using AD.Exodius.Registries;

namespace AD.Exodius.Components;

public class PageComponent : IPageComponent
{
    protected readonly IDriver Driver;
    protected readonly IPageComponentRegistry Owner;

    public PageComponent(
        IDriver driver,
        IPageComponentRegistry owner)
    {
        Owner = owner;
        Driver = driver;
    }
}
