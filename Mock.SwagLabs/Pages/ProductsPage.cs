using AD.Exodius.Components.Factories;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Attributes;
using Mock.SwagLabs.Components.Sections;

namespace Mock.SwagLabs.Pages;

[PageObjectRoute("/inventory.html")]
public class ProductsPage : PageObject
{
    public ProductsPage(
        IDriver driver,
        IPageComponentFactory componentFactory) 
        : base(driver)
    {
        AddComponents(
        [
            componentFactory.Create<IProductSortSection>(),
            componentFactory.Create<IInventorySection>(),
        ]);
    }
}
