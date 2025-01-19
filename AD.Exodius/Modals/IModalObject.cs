using AD.Exodius.Registries;

namespace AD.Exodius.Modals;

/// <summary>
/// Represents a modal object within the page component registry.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IPageComponentRegistry"/> and provides a contract for modal components
/// that are part of the page structure. Implementing this interface ensures that the modal component can be
/// registered and managed within the page component lifecycle.
/// </remarks>
public interface IModalObject : IPageComponentRegistry 
{ 

}
