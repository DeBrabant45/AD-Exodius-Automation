using AD.Exodius.Configuration;
using AD.Exodius.Driver;

namespace Mock.SwagLabs.Tests.Fixture;

public class BaseTestFixture : XunitContextBase
{
    protected readonly IDriver Driver;
    protected readonly TestSettings Settings;

    public BaseTestFixture(ITestOutputHelper output, IDriver driver, TestSettings settings)
        : base(output)
    {
        Driver = driver;
        Settings = settings;
        Driver.GoToUrl(settings.ApplicationUrl);
    }

    public override void Dispose()
    {
        var theExceptionThrownByTest = Context.TestException;
        var testDisplayName = Context.Test.DisplayName;
        var testCase = Context.Test.TestCase;
        if (theExceptionThrownByTest != null)
        {
            Console.WriteLine("This is where we capture info of failed tests");
        }
        base.Dispose();
        Driver.Quit();
    }
}
