using Mock.Tests.Fixture;
using PlaywrightLibrary.Configuration;
using PlaywrightLibrary.Driver;
using PlaywrightLibrary.Elements;

namespace Mock.Tests;

public class UnitTest1 : BaseTestFixture
{
    public UnitTest1(ITestOutputHelper output, IDriver driver, TestSettings settings) 
        : base(output, driver, settings)
    {
        Driver.GoToUrl(Settings.ApplicationUrl);
    }

    [Theory, AutoData]
    public async Task Test1()
    {
        TextInputElement NameField = Driver.FindElementById<TextInputElement>("name");
        await NameField.TypeInput("Hello");
        var actualText = await NameField.Text();
        Assert.Equal("Hello", actualText);
    }
}