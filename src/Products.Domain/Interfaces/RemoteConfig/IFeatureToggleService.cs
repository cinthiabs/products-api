namespace Products.Domain.Interfaces.RemoteConfig;

public interface IFeatureToggleService
{
    Task<bool> GetRuleDeleteOrDisableProduct(CancellationToken cancellationToken);
}
