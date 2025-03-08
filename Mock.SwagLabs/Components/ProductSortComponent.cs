using AD.Exodius.Components;
using AD.Exodius.Locators;
using AD.Exodius.Pages;
using AD.Exodius.Utility.Enums;
using Mock.SwagLabs.Components.Enums;

namespace Mock.SwagLabs.Components;

public class ProductSortComponent(IDriver driver, IPageObject owner) 
    : PageComponent(driver, owner), IProductSortComponent
{
    private SelectElement ProductSelectElement => Driver.FindElement<ByTestData, SelectElement>("product-sort-container");

    public async Task<IProductSortComponent> SetFilter(ProductFilter filter)
    {
        await ProductSelectElement.SelectValue(filter.GetHtmlValue());

        return this;
    }
}
