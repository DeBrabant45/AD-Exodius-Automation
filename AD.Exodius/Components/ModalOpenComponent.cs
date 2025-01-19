using AD.Exodius.Drivers;
using AD.Exodius.Modals;
using AD.Exodius.Modals.Factories;
using AD.Exodius.Pages;

namespace AD.Exodius.Components;

public abstract class ModalOpenComponent : PageComponent, IModalOpenComponent
{
    public ModalOpenComponent(
        IDriver driver,
        IPageObject owner) 
        : base(driver, owner)
    {

    }

    public virtual async Task<TModalObject> OpenModal<TModalObject>() where TModalObject : ModalObject
    {
        await TriggerOpen();

        var modal = ModalFactory.Create<TModalObject>(Driver, (IPageObject)Owner);
        modal.InitializeLazyComponents();

        return modal;
    }

    protected abstract Task TriggerOpen();
}
