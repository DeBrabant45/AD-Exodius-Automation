using AD.Exodius.Drivers;
using AD.Exodius.Pages;

namespace AD.Exodius.Modals.Factories;

public class ModalFactory
{
    public static TModalObject Create<TModalObject>(IDriver driver, IPageObject owner) where TModalObject : ModalObject
    {
        ArgumentNullException.ThrowIfNull(driver);
        ArgumentNullException.ThrowIfNull(owner);

        var instance = Activator.CreateInstance(typeof(TModalObject), driver, owner)
            ?? throw new InvalidOperationException($"Failed to create an instance of {typeof(TModalObject).Name}.");

        return (TModalObject)instance;
    }
}
