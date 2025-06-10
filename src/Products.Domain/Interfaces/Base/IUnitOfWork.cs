namespace Products.Domain.Interfaces.Base;

public interface IUnitOfWork
{
    void BeginTransation();
    Task BeginTransationAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
}
