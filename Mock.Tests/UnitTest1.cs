using PlaywrightLibrary.Configuration;
using PlaywrightLibrary.Driver;

namespace Mock.Tests;

public class UnitTest1
{
    private readonly IDriver _driver;

    public UnitTest1()
    {
        _driver = new PageDriver();
        var testSettings = ConfigurationReader.Read();
        _driver.Start(testSettings);
    }

    [Theory, AutoData]
    public void Test1()
    {

    }
}