namespace AD.Exodius.Pages.Factories;

public class PageObjectFactory : IPageObjectFactory
{
    private readonly HashSet<IPageObject> _pages;

    public PageObjectFactory(IEnumerable<IPageObject> pages)
    {
        if (pages == null || !pages.Any())
            throw new ArgumentException("No pages provided or found in the provided collection.");

        _pages = new HashSet<IPageObject>(pages);

        if (_pages.Count != pages.Count())
        {
            var duplicatePages = pages.GroupBy(p => p)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            var duplicatePageNames = string.Join(", ", duplicatePages.Select(p => p.GetType().Name));

            throw new ArgumentException($"Duplicate pages provided: {duplicatePageNames}");
        }
    }

    public TPage Create<TPage>() where TPage : IPageObject
    {
        return _pages.OfType<TPage>().FirstOrDefault()
            ?? throw new InvalidOperationException($"No page of type {typeof(TPage).Name} found.");
    }
}
