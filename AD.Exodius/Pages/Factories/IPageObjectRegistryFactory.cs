using AD.Exodius.Pages.Registries;

namespace AD.Exodius.Pages.Factories;

public interface IPageObjectRegistryFactory
{
    IPageObjectRegistry? Create<TPageObject>(TPageObject page) where TPageObject : IPageObject;
}
