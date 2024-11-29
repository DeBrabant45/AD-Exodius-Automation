﻿using AD.Exodius.Networks;

namespace AD.Exodius.Driver.Factories;

public class NetworkResponseFactory : INetworkResponseFactory
{
    public TNetworkResponse Create<TNetworkResponse>(Task<IResponse> response) where TNetworkResponse : INetworkResponse
    {
        return (TNetworkResponse)Activator.CreateInstance(typeof(TNetworkResponse), response);
    }
}