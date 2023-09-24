namespace AD.Exodius.Locators;

public class XPathFindStrategy : FindStrategy
{
    public XPathFindStrategy(string value) : base(value)
    {

    }

    public override string Convert() => $"xpath={Value}";
}