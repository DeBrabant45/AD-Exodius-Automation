using AD.Exodius.Drivers;
using AD.Exodius.Pages;
using AD.Exodius.Registries;

namespace AD.Exodius.Modals;

public class ModalObject : PageComponentRegistry, IModalObject
{
    protected readonly IPageObject Owner;

    public ModalObject(IDriver driver, IPageObject owner) 
        : base(driver)
    {
        Owner = owner;
    }
}
