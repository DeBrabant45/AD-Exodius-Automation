using Mock.SwagLabs.Models;
using Mock.SwagLabs.Sections.Navigationbar;

namespace Mock.SwagLabs.Pages;

public class InventoryPage : BasePage
{
    private NavigationbarSection _navigationbar;

    public InventoryPage(IDriver driver, NavigationbarSection navigationbar) 
        : base(driver)
    {
        _navigationbar = navigationbar;
    }

    private DropdownElement FilterDropdown => Driver.FindElementByTestData<DropdownElement>("product_sort_container");

    public async Task SetFilter(Inventory inventory)
    {
        await FilterDropdown.SelectValue(inventory.Filter.ToString().ToLower());
    }
}