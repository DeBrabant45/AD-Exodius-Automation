namespace AD.Playwrightlib.Locators;

public class TextFindStrategy : FindStrategy
{
    public TextFindStrategy(string value) : base(value)
    {
    }

    public override string Convert() => $"text={Value}";
}
