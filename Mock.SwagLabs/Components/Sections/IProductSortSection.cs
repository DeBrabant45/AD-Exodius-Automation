using AD.Exodius.Components;
using Mock.SwagLabs.Components.Enums;

namespace Mock.SwagLabs.Components.Sections;

public interface IProductSortSection : IPageComponent
{
    public Task<IProductSortSection> SetFilter(ProductFilter filter);
}