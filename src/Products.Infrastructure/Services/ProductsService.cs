using Ardalis.Result;
using Products.Domain.Dtos;
using Products.Domain.Interfaces.Base;
using Products.Domain.Interfaces.Repositories;
using Products.Domain.Interfaces.Services;

namespace Products.Infrastructure.Services;

public class ProductsService(IUnitOfWork unitOfWork, IProductsRepository productsRepository) : IProductsService
{
    public async Task<Result> CreateProductsAsync(CreateProductDto createProductsDto, CancellationToken cancellationToken)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync(cancellationToken);

            var createProducts = await productsRepository.CreateProductsAsync(createProductsDto, cancellationToken);

            await productsRepository.CreateItemsAsync(createProductsDto.Items, createProducts.ProductId, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return Result.Success();
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync(cancellationToken);
            return Result.Error(ex.Message);
        }
    }

    public async Task<Result<bool>> RemoveProductsAsync(int idProduct, bool remove, CancellationToken cancellationToken)
    {
        var product = await productsRepository.GetProductByIdAsync(idProduct, cancellationToken);
        if (product == null)
            return Result.Invalid();

        var success = remove
            ? await productsRepository.RemoveProductsAsync(idProduct, cancellationToken)
            : await productsRepository.InactiveProductsAsync(idProduct, cancellationToken);

        return success
            ? Result.Success(true)
            : Result.Error();
    }

}