using AD.Exodius.Pages;
using AD.Exodius.Pages.Registries;
using Mock.SwagLabs.Components;

namespace Mock.SwagLabs.Pages.Registries;

public class ProductsPageRegistry : IPageObjectRegistry
{
    public void RegisterComponents<TPage>(TPage page) where TPage : IPageObject
    {
        page.AddComponent<WaitComponent>();
        page.AddComponent<ProductSortComponent>();
        page.AddComponent<InventoryComponent>();
        page.AddComponent<NavigationActionComponent>();
    }
}
