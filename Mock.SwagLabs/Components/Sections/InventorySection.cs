using AD.Exodius.Components;
using AD.Exodius.Locators;

namespace Mock.SwagLabs.Components.Sections;

public class InventorySection : IInventorySection
{
    private readonly IDriver _driver;

    public InventorySection(IDriver driver)
    {
        _driver = driver;
    }

    private Task<List<LabelElement>> ItemNames => _driver.FindAllElements<ByTestData, LabelElement>("inventory-item-name");

    private Task<List<LabelElement>> ItemPrices => _driver.FindAllElements<ByTestData, LabelElement>("inventory-item-price");

    public async Task<List<string>> GetAllItemNamesInOrder()
    {
        return await GetAllLabelElementsInOrder<string>(ItemNames);
    }

    public async Task<List<TPrimitive>> GetAllPricesInOrder<TPrimitive>()
    {
        return await GetAllLabelElementsInOrder<TPrimitive>(ItemPrices);
    }

    private async Task<List<TPrimitive>> GetAllLabelElementsInOrder<TPrimitive>(Task<List<LabelElement>> elements)
    {
        var elementsInOrder = new List<TPrimitive>();
        foreach (var element in await elements)
        {
            elementsInOrder.Add(await element.GetTextAsType<TPrimitive>());
        }

        return elementsInOrder;
    }
}
