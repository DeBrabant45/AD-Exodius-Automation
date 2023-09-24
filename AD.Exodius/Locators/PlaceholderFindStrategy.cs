namespace AD.Exodius.Locators;

public class PlaceholderFindStrategy : FindStrategy
{
    public PlaceholderFindStrategy(string value) : base(value)
    {
    }

    public override string Convert() => $"placeholder={Value}";
}
