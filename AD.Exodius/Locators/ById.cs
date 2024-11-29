namespace AD.Exodius.Locators;

/// <summary>
/// Represents a locator strategy based on an HTML Id.
/// </summary>
/// <remarks>
/// <para>This strategy selects elements with a specific id value.</para>
/// <para>Note: The "id=" prefix should not be included in your value.</para>
/// </remarks>
/// <author>Aaron DeBrabant</author>
public class ById : LocatorStrategy
{
    public ById(string value) : base(value)
    {

    }

    public override string Convert() => $"id={Value}";
}
