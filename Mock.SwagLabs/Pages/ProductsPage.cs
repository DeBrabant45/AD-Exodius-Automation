using AD.Exodius.Pages;
using AD.Exodius.Pages.Attributes;
using Mock.SwagLabs.Pages.Registries;

namespace Mock.SwagLabs.Pages;

[PageObjectMeta(
    Route = "/inventory.html",
    Name = "Products",
    DomId = "inventory-sidebar-link",
    Registry = typeof(ProductsPageRegistry)
)]
public class ProductsPage(IDriver driver) : PageObject(driver)
{

}
