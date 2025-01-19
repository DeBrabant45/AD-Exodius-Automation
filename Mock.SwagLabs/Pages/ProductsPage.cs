using AD.Exodius.Pages;
using AD.Exodius.Pages.Attributes;
using Mock.SwagLabs.Components.Sections;

namespace Mock.SwagLabs.Pages;

[PageObjectMeta(
    Route = "/inventory.html",
    Name = "Products",
    DomId = "inventory-sidebar-link"
)]
public class ProductsPage : PageObject
{
    public ProductsPage(IDriver driver)
        : base(driver)
    {
        AddComponent<WaitSection>();
        AddComponent<ProductSortSection>();
        AddComponent<InventorySection>();
        AddComponent<NavigationActionComponent>();
    }
}
