using AD.Exodius.Elements;

namespace AD.Exodius.Driver;

public interface IElementFindService
{
    public TElement FindElementById<TElement>(string id) where TElement : IElement;

    public TElement FindElementByCss<TElement>(string css) where TElement : IElement;

    public TElement FindElementByXPath<TElement>(string xpath) where TElement : IElement;

    public TElement FindElementByTestData<TElement>(string testdata) where TElement : IElement;

    public TElement FindElementByText<TElement>(string text) where TElement : IElement;

    public TElement FindElementByPlaceholder<TElement>(string placeholder) where TElement : IElement;

    public List<TElement> FindAllElementsById<TElement>(string id) where TElement : IElement;
    
    public List<TElement> FindAllElementsByXPath<TElement>(string xpath) where TElement : IElement;

    public List<TElement> FindAllElementsByText<TElement>(string text) where TElement : IElement;

    public List<TElement> FindAllElementsByCss<TElement>(string css) where TElement : IElement;

    public List<TElement> FindAllElementsByTestData<TElement>(string testdata) where TElement : IElement;
}
