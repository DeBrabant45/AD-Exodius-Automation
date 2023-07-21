using PlaywrightLibrary.Elements;

namespace PlaywrightLibrary.Driver;

public class ElementFactory : IElementFactory
{
    public TElement Create<TElement>(ILocator locator) where TElement : IElement
    {
        return (TElement)Activator.CreateInstance(typeof(TElement), locator);
    }
}