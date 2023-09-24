namespace AD.Exodius.Locators;

public class CssSelectorFindStrategy : FindStrategy
{
    public CssSelectorFindStrategy(string value) : base(value)
    {
    }

    public override string Convert() => $"css={Value}";
}
