using AD.Exodius.Elements;

namespace AD.Exodius.Driver;

public interface INavigationService
{
    public Task GoToUrl(string url);
    public Task Refresh();
    public void SwitchToDefaultPage();
    public void SwitchToPage(int index);
    public Task SwitchToNewPage(IClickElement clickableElement);
    public Task ClosePage(int index);
}