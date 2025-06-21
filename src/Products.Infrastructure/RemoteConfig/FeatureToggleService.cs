using Products.Domain.Interfaces.RemoteConfig;

namespace Products.Infrastructure.RemoteConfig;

public class FeatureToggleService(IConfigCatRemoteConfig configCat) : IFeatureToggleService
{
    private const string FLAG_DELETE_PRODUCT  = "flag_delete_product";
    
    public async Task<bool> GetRuleDeleteProduct(CancellationToken cancellationToken)
    {
        return await configCat.GetValueAsync(FLAG_DELETE_PRODUCT, false, cancellationToken);
    }
}
