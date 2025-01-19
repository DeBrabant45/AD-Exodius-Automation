using AD.Exodius.Components;
using AD.Exodius.Locators;
using AD.Exodius.Pages;
using AD.Exodius.Utility.Enums;
using Mock.SwagLabs.Components.Enums;

namespace Mock.SwagLabs.Components.Sections;

public class ProductSortSection : PageComponent, IProductSortSection
{
    public ProductSortSection(
        IDriver driver,
        IPageObject owner) 
        : base(driver, owner)
    {

    }

    private SelectElement ProductSelectElement => Driver.FindElement<ByTestData, SelectElement>("product-sort-container");

    public async Task<IProductSortSection> SetFilter(ProductFilter filter)
    {
        await ProductSelectElement.SelectValue(filter.GetHtmlValue());

        return this;
    }
}
