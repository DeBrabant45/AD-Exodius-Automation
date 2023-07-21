using PlaywrightLibrary.Configuration;
using PlaywrightLibrary.Driver;
using PlaywrightLibrary.Elements;

namespace Mock.Tests;

public class UnitTest1
{
    private readonly IDriver _driver;
    private readonly TestSettings _settings;

    public UnitTest1(IDriver driver, TestSettings settings)
    {
        _driver = driver;
        _settings = settings;
    }

    [Theory, AutoData]
    public async Task Test1()
    {
        await _driver.GoToUrl(_settings.ApplicationUrl);
        TextInputElement NameField = _driver.FindElementById<TextInputElement>("name");
        await NameField.TypeInput("Hello");
        var actualText = await NameField.Text();
    }
}