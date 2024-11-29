using AD.Exodius.Navigators.Strategies;

namespace AD.Exodius.Navigators.Factories;

public class NavigationStrategyFactory : INavigationStrategyFactory
{
    public INavigationStrategy Create<TNavigation>() where TNavigation : INavigationStrategy
    {
        return (TNavigation)Activator.CreateInstance(typeof(TNavigation));
    }
}
