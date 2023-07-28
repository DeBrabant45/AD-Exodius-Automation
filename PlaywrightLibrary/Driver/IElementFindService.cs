using PlaywrightLibrary.Elements;
using PlaywrightLibrary.Locators;

namespace PlaywrightLibrary.Driver;

public interface IElementFindService
{
    public TElement Find<TElement>(FindStrategy findStrategy) where TElement : IElement;

    public TElement FindElementById<TElement>(string id) where TElement : IElement;

    public TElement FindElementByCss<TElement>(string css) where TElement : IElement;

    public TElement FindElementByXPath<TElement>(string xpath) where TElement : IElement;

    public TElement FindElementByTestData<TElement>(string xpath) where TElement : IElement;
}
