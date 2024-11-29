using AD.Exodius.Driver;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Attributes;

namespace AD.Exodius.UnitTests.Stubs.PageObjects;

[PageObjectName("Sample Attribute")]
public class StubSampleAttributePageObject : PageObject
{
    public StubSampleAttributePageObject(IDriver driver)
        : base(driver)
    {

    }
}