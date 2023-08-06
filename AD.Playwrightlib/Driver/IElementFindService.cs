using AD.Playwrightlib.Elements;
using AD.Playwrightlib.Locators;

namespace AD.Playwrightlib.Driver;

public interface IElementFindService
{
    public TElement Find<TElement>(FindStrategy findStrategy) where TElement : IElement;

    public TElement FindElementById<TElement>(string id) where TElement : IElement;

    public TElement FindElementByCss<TElement>(string css) where TElement : IElement;

    public TElement FindElementByXPath<TElement>(string xpath) where TElement : IElement;

    public TElement FindElementByTestData<TElement>(string xpath) where TElement : IElement;

    public TElement FindElementByClassName<TElement>(string xpath) where TElement : IElement;
}
