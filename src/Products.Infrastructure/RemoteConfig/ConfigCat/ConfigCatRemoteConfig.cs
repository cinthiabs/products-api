using ConfigCat.Client;
using Products.Domain.Interfaces.RemoteConfig;

namespace Products.Infrastructure.RemoteConfig.ConfigCat;

public class ConfigCatRemoteConfig(IConfigCatClient client) : IConfigCatRemoteConfig
{
    public Task<T> GetValueAsync<T>(string key, T defaultValue, CancellationToken cancellationToken = default)
    {
        return client.GetValueAsync(key, defaultValue, cancellationToken: cancellationToken);
    }
}
