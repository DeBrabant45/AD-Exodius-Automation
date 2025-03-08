using AD.Exodius.Components;

namespace Mock.SwagLabs.Components;

public interface IInventoryComponent : IPageComponent
{
    Task<List<string>> GetAllItemNamesInOrder();

    Task<List<TPrimitive>> GetAllPricesInOrder<TPrimitive>();
}