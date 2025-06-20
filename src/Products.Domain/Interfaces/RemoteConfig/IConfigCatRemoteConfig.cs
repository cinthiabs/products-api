namespace Products.Domain.Interfaces.RemoteConfig;

public interface IConfigCatRemoteConfig
{
    Task<T> GetValueAsync<T>(string key, T defaultValue, CancellationToken cancellationToken = default);
}
