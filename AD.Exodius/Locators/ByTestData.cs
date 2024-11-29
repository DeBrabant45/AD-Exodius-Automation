namespace AD.Exodius.Locators;

/// <summary>
/// Represents a locator strategy based on an HTML test data.
/// </summary>
/// <remarks>
/// <para>This strategy selects elements with a specific test data id value.</para>
/// <para>Note: The "data-test=" prefix should not be included in your value.</para>
/// </remarks>
/// <author>Aaron DeBrabant</author>
public class ByTestData : LocatorStrategy
{
    public ByTestData(string value) : base(value)
    {
    }

    public override string Convert() => $"data-test={Value}";
}
