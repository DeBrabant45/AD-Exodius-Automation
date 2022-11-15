using System.Threading.Tasks;

namespace PlaywrightLibrary.Driver;

public interface INavigationService
{
    public Task GoToUrl(string url);
}