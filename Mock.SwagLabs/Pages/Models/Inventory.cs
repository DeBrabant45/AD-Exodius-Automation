using Mock.SwagLabs.Pages.Enums;

namespace Mock.SwagLabs.Pages.Models;

public class Inventory
{
    public InventoryFilter Filter { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
