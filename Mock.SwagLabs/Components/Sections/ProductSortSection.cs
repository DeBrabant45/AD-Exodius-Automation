using AD.Exodius.Drivers;
using AD.Exodius.Locators;
using AD.Exodius.Utility.Enums;
using Mock.SwagLabs.Components.Enums;

namespace Mock.SwagLabs.Components.Sections;

public class ProductSortSection : IProductSortSection
{
    private readonly IDriver _driver;

    public ProductSortSection(IDriver driver)
    {
        _driver = driver;
    }

    private SelectElement ProductSelectElement => _driver.FindElement<ByTestData, SelectElement>("product-sort-container");

    public async Task<IProductSortSection> SetFilter(ProductFilter filter)
    {
        await ProductSelectElement.SelectValue(filter.GetHtmlValue());

        return this;
    }
}
