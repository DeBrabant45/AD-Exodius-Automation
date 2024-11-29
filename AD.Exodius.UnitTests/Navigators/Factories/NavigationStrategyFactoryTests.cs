using AD.Exodius.Navigators.Factories;
using AD.Exodius.Navigators.Strategies;

namespace AD.Exodius.UnitTests.Navigators.Factories;

public class NavigationStrategyFactoryTests
{
    private readonly NavigationStrategyFactory _sut; 

    public NavigationStrategyFactoryTests()
    {
        _sut = new NavigationStrategyFactory();
    }

    [Fact]
    public void Create_ShouldReturn_InstanceOfNavigationStrategy()
    {
        var result = _sut.Create<ByRoute>();

        Assert.NotNull(result);
        Assert.IsType<ByRoute>(result);
    }

    [Fact]
    public void Create_ShouldReturn_DifferentInstanceEachTime()
    {
        var firstInstance = _sut.Create<ByRoute>();
        var secondInstance = _sut.Create<ByRoute>();

        Assert.NotSame(firstInstance, secondInstance); 
    }
}
