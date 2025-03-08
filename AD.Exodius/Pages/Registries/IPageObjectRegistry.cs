namespace AD.Exodius.Pages.Registries;

public interface IPageObjectRegistry
{
    void RegisterComponents<TPage>(TPage page) where TPage : IPageObject;
}