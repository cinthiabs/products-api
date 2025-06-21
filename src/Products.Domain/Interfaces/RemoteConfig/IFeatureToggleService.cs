namespace Products.Domain.Interfaces.RemoteConfig;

public interface IFeatureToggleService
{
    Task<bool> GetRuleDeleteProduct(CancellationToken cancellationToken);
}
