using AD.Exodius.Elements;

namespace AD.Exodius.Drivers.Factories;

public class ElementFactory : IElementFactory
{
    public TElement Create<TElement>(ILocator locator) where TElement : IElement
    {
        var instance = Activator.CreateInstance(typeof(TElement), locator)
            ?? throw new InvalidOperationException($"Failed to create an instance of {typeof(TElement).Name}.");

        return (TElement)instance;
    }
}