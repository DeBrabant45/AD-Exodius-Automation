namespace Mock.SwagLabs.Models;

public class Inventory
{
    public InventoryFilter Filter { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public enum InventoryFilter
{
    AZ,
    ZA,
    LoHi,
    HiLo,
}
