namespace PlaywrightLibrary.Locators;

public class IdFindStrategy : FindStrategy
{
    public IdFindStrategy(string value) : base(value)
    {

    }

    public override string Convert() => $"id={Value}";
}
