using AD.Exodius.Drivers;
using AD.Exodius.Pages;
using AD.Exodius.Pages.Attributes;

namespace AD.Exodius.UnitTests.Stubs.PageObjects;

[PageObjectName("Sample Attribute")]
public class StubSampleAttributePageObject(IDriver driver) : PageObject(driver)
{

}