using AD.Exodius.Driver.Services;

namespace AD.Exodius.Driver;

/// <summary>
/// Represents a driver interface for interacting with web pages.
/// </summary>
/// <remarks>
/// This interface combines several services for browser interaction, navigation, element finding, waiting, storage, screenshot capturing, tracing, and network interaction.
/// </remarks>
/// <author>Aaron DeBrabant</author>
public interface IDriver : IBrowserService, INavigationService, IElementFindService, IWaitService, IStorageService, IDiagnosticsService, INetworkFindService
{

}