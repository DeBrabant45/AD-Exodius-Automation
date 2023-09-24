using AD.Exodius.Configuration;
using AD.Exodius.Driver;
using Mock.SwagLabs.Models;
using Mock.SwagLabs.Pages;
using Mock.SwagLabs.Tests.Fixture;

namespace Mock.SwagLabs.Tests.InventoryTests;

public class InventoryTests : BaseTestFixture
{
    private LoginPage _loginPage;
    private InventoryPage _inventoryPage;

    public InventoryTests(ITestOutputHelper output, IDriver driver, 
        TestSettings settings, LoginPage loginPage, InventoryPage inventoryPage) 
        : base(output, driver, settings)
    {
        _loginPage = loginPage;
        _inventoryPage = inventoryPage;
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce")]
    public async Task SauceLabsBackpack_Should_Be_Added_To_ShoppingCart(string username, string password)
    {
        var login = new Login { Username = username, Password = password };
        var inventory = new Inventory { Filter = InventoryFilter.ZA };
        await _loginPage.LoginToSwagLabs(login);
        await _inventoryPage.SetFilter(inventory);
    }
}
