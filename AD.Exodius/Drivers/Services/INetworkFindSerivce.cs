using AD.Exodius.Networks;

namespace AD.Exodius.Drivers.Services;

/// <summary>
/// Represents a service for finding network responses.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface INetworkFindService
{
    /// <summary>
    /// Finds a network response with the specified network URL.
    /// </summary>
    /// <typeparam name="TNetworkResponse">The type of network response to find.</typeparam>
    /// <param name="networkUrl">The URL of the network response to find.</param>
    /// <returns>The found network response.</returns>
    public TNetworkResponse FindNetworkResponse<TNetworkResponse>(string networkUrl) where TNetworkResponse : INetworkResponse;

    /// <summary>
    /// Finds all network responses with the specified network URL.
    /// </summary>
    /// <typeparam name="TNetworkResponse">The type of network responses to find.</typeparam>
    /// <param name="networkUrl">The URL of the network responses to find.</param>
    /// <returns>A list of found network responses.</returns>
    public List<TNetworkResponse> FindAllNetworkResponses<TNetworkResponse>(string networkUrl) where TNetworkResponse : INetworkResponse;
}
