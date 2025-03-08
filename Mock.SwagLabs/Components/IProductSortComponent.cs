using AD.Exodius.Components;
using Mock.SwagLabs.Components.Enums;

namespace Mock.SwagLabs.Components;

public interface IProductSortComponent : IPageComponent
{
    Task<IProductSortComponent> SetFilter(ProductFilter filter);
}