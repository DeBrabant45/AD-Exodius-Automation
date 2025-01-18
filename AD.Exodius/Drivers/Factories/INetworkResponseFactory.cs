using AD.Exodius.Networks;

namespace AD.Exodius.Drivers.Factories;

/// <summary>
/// Represents a factory for creating network response instances.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface INetworkResponseFactory
{
    /// <summary>
    /// Creates a network response of type <typeparamref name="TNetworkResponse"/> based on the provided response task.
    /// </summary>
    /// <typeparam name="TNetworkResponse">The type of network response to create.</typeparam>
    /// <param name="response">The task representing the response.</param>
    /// <returns>The created network response.</returns>
    TNetworkResponse Create<TNetworkResponse>(Task<IResponse> response) where TNetworkResponse : INetworkResponse;
}