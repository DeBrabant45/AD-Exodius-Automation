using AD.Exodius.Components;
using AD.Exodius.Drivers;
using AD.Exodius.Pages;
using AD.Exodius.Registries;
using NSubstitute;

namespace AD.Exodius.UnitTests.Components;

public class ComponentExampleTest
{
    private readonly ExampleComponent _sut;
    private readonly IDriver _mockDriver;
    private readonly IPageObject _mockPageObject;

    public ComponentExampleTest()
    {
        _mockDriver = Substitute.For<IDriver>();
        _mockPageObject = Substitute.For<IPageObject>();
        _mockPageObject.AddComponent<IDoer>();
        _sut = new ExampleComponent(_mockDriver, _mockPageObject);
    }

    [Fact]
    public void DoerComponentDoSomething_ShouldBe_Invoked()
    {
        // Arrange
        var doerMock = _mockPageObject.GetComponent<IDoer>();
        _sut.Initialize();

        // Act
        _sut.DoAction();

        // Assert
        doerMock.Received(1).DoSomething();
    }

    public interface IDoer : IPageComponent
    {
        void DoSomething();
    }

    public class ExampleComponent(IDriver driver, IPageComponentRegistry owner) 
        : LazyPageComponent(driver, owner)
    {
        private IDoer? _doerComponent;

        public override void Initialize()
        {
            _doerComponent = Owner.GetComponent<IDoer>();
        }

        public void DoAction()
        {
            _doerComponent?.DoSomething();
        }
    }
}
