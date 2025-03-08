using AD.Exodius.Components;
using AD.Exodius.Locators;
using AD.Exodius.Pages;

namespace Mock.SwagLabs.Components;

public class InventoryComponent(IDriver driver, IPageObject owner) 
    : PageComponent(driver, owner), IInventoryComponent
{
    private Task<List<LabelElement>> ItemNames => Driver.FindAllElements<ByTestData, LabelElement>("inventory-item-name");

    private Task<List<LabelElement>> ItemPrices => Driver.FindAllElements<ByTestData, LabelElement>("inventory-item-price");

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
