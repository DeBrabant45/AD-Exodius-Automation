using System.Text.Json;

namespace AD.Exodius.Networks;

public class NetworkResponse : INetworkResponse
{
    private readonly Task<IResponse> _response;

    public NetworkResponse(Task<IResponse> response)
    {
        _response = response;
    }

    public async Task<T> JsonResponse<T>()
    {
        var response = await _response;
        return await response.JsonAsync<T>();
    }

    public async Task<JsonElement?> JsonResponse()
    {
        var response = await _response;
        return await response.JsonAsync();
    }

    public async Task<byte[]> Body()
    {
        var response = await _response;
        return await response.BodyAsync();
    }

    public async Task<JsonElement> Payload()
    {
        var response = await _response;
        return response.Request.PostDataJSON().Value;
    }
}
