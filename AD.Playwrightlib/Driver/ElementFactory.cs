using AD.Playwrightlib.Elements;

namespace AD.Playwrightlib.Driver;

public class ElementFactory : IElementFactory
{
    public TElement Create<TElement>(ILocator locator) where TElement : IElement
    {
        return (TElement)Activator.CreateInstance(typeof(TElement), locator);
    }
}