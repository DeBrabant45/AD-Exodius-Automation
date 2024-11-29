namespace AD.Exodius.Driver.Factories;

/// <summary>
/// Represents a factory for creating instances of Playwright.
/// </summary>
/// <remarks>
/// This factory provides a method to create an instance of Playwright.
/// It ensures that a single Node.js runtime is launched for all tests when Playwright is created.
/// </remarks>
/// <author>Aaron DeBrabant</author>
public class PlaywrightFactory
{
    private static IPlaywright? _playwrightInstance;

    /// <summary>
    /// Creates an instance of Playwright.
    /// </summary>
    /// <returns>The created instance of Playwright.</returns>
    public static IPlaywright Create()
    {
        if (_playwrightInstance != null)
            return _playwrightInstance;
       
        return _playwrightInstance = Playwright.CreateAsync().GetAwaiter().GetResult();
    }
}
