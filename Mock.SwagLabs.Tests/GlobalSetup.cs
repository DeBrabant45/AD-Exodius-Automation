using System.Runtime.CompilerServices;

namespace Mock.SwagLabs.Tests;

public class GlobalSetup
{
    /// <summary>
    /// Allows using Context.TestException from XUnitContext. See https://github.com/SimonCropp/XunitContext#test-failure
    /// </summary>
    [ModuleInitializer]
    public static void Setup() => XunitContext.EnableExceptionCapture();
}
