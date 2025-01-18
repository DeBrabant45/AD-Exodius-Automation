using AD.Exodius.Locators;

namespace AD.Exodius.Drivers.Factories;

public class LocatorStrategyFactory : ILocatorStrategyFactory
{
    public TLocatorStrategy Create<TLocatorStrategy>(params string[] values) where TLocatorStrategy : LocatorStrategy
    {
        if (values.Length == 0)
            throw new ArgumentException("At least one value must be provided.", nameof(values));

        return Activator.CreateInstance(typeof(TLocatorStrategy), values) as TLocatorStrategy ??
            throw new InvalidOperationException($"Failed to create instance of {typeof(TLocatorStrategy).Name}");
    }
}
