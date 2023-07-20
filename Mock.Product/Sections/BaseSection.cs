namespace Mock.Product.Sections;

public abstract class BaseSection
{
    protected IDriver Driver;

    protected BaseSection(IDriver driver)
    {
        Driver = driver;
    }
}
