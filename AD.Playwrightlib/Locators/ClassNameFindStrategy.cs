namespace AD.Playwrightlib.Locators;

public class ClassNameFindStrategy : FindStrategy
{
    public ClassNameFindStrategy(string value) : base(value)
    {
    }

    public override string Convert() => $"class={Value}";
}
