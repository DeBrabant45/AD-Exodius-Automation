using AD.Exodius.Elements;

namespace AD.Exodius.Driver;
public interface IElementFactory
{
    TElement Create<TElement>(ILocator locator) where TElement : IElement;
}