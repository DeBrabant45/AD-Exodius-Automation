using AD.Exodius.Components;

namespace Mock.SwagLabs.Components.Sections;

public interface IInventorySection : IPageComponent
{
    public Task<List<string>> GetAllItemNamesInOrder();

    public Task<List<TPrimitive>> GetAllPricesInOrder<TPrimitive>();
}