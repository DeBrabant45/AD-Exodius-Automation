using AD.Exodius.Drivers;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Attributes;

namespace AD.Exodius.UnitTests.Stubs.PageObjects;

[PageObjectName("Basic Attribute")]
[PageObjectRoute("/basic")]
public class StubBasicAttributePageObject : PageObject
{
    public StubBasicAttributePageObject(IDriver driver)
        : base(driver)
    {

    }
}
