namespace AD.Exodius.Locators;

public abstract class FindStrategy
{
    protected FindStrategy(string value)
    {
        Value = value;
    }

    public string Value { get; }
    public abstract string Convert();
}
