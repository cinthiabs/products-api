using Products.Domain.Interfaces.RemoteConfig;

namespace Products.Infrastructure.RemoteConfig;

public class FeatureToggleService(IConfigCatRemoteConfig configCat) : IFeatureToggleService
{
    private const string FLAG_DELETE_OR_DISABLE  = "flag_delete_or_disable_product";
    
    public async Task<bool> GetRuleDeleteOrDisableProduct(CancellationToken cancellationToken)
    {
        return await configCat.GetValueAsync(FLAG_DELETE_OR_DISABLE, false, cancellationToken);
    }
}
