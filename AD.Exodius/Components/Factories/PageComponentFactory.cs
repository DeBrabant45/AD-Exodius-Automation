namespace AD.Exodius.Components.Factories;

public class PageComponentFactory : IPageComponentFactory
{
    private readonly HashSet<IPageComponent> _pageComponents;

    public PageComponentFactory(IEnumerable<IPageComponent> pageComponents)
    {
        if (pageComponents == null || !pageComponents.Any())
            throw new ArgumentException("No components found in the provided collection from startup!");

        _pageComponents = new HashSet<IPageComponent>(pageComponents);
    }

    public TPageComponent Create<TPageComponent>() where TPageComponent : IPageComponent
    {
        return _pageComponents
            .OfType<TPageComponent>()
            .FirstOrDefault()
            ?? throw new InvalidOperationException($"{typeof(TPageComponent).Name} does not exist in the provided collection from startup!");
    }
}
