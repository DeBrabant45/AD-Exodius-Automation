using AD.Exodius.Modals;

namespace AD.Exodius.Components;

/// <summary>
/// Defines a component capable of opening a modal.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IModalOpenComponent
{
    /// <summary>
    /// Opens a modal of the specified type.
    /// </summary>
    /// <typeparam name="TModalObject">The type of the modal object to open.</typeparam>
    /// <returns>
    /// A task that represents the asynchronous operation of opening the modal.
    /// The task result contains an instance of the modal object.
    /// </returns>
    public Task<TModalObject> OpenModal<TModalObject>() where TModalObject : ModalObject;
}
