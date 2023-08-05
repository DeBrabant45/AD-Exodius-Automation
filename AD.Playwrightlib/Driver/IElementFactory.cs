using AD.Playwrightlib.Elements;

namespace AD.Playwrightlib.Driver;
public interface IElementFactory
{
    TElement Create<TElement>(ILocator locator) where TElement : IElement;
}