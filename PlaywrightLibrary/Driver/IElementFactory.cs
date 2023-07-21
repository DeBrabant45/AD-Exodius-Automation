using PlaywrightLibrary.Elements;

namespace PlaywrightLibrary.Driver;
public interface IElementFactory
{
    TElement Create<TElement>(ILocator locator) where TElement : IElement;
}