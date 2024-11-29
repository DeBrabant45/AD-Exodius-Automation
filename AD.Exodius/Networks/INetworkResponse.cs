using System.Text.Json;

namespace AD.Exodius.Networks;

public interface INetworkResponse
{
    public Task<T> JsonResponse<T>();
    public Task<byte[]> Body();
    public Task<JsonElement?> JsonResponse();
    public Task<JsonElement> Payload();
}
