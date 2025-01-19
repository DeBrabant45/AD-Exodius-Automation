using AD.Exodius.Drivers;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Attributes;

namespace AD.Exodius.UnitTests.Stubs.PageObjects;

[PageObjectMeta(
    Route = "/home",
    Name = "Example",
    DomId = "test"
)]
public class StubMetaPageObject(IDriver driver) : PageObject(driver)
{

}
