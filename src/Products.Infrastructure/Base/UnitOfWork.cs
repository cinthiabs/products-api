﻿using Microsoft.Data.SqlClient;
using Products.Domain.Interfaces.Base;

namespace Products.Infrastructure.Base;

public class UnitOfWork(DbContext dbContext) : IUnitOfWork, IDisposable
{
    public void BeginTransation()
    {
        dbContext.Connection.Open();
        dbContext.Transaction = dbContext.Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
    }

    public async Task BeginTransationAsync(CancellationToken cancellationToken)
    {
        if(dbContext.Connection.State != System.Data.ConnectionState.Open)
            await dbContext.Connection.OpenAsync(cancellationToken);

        dbContext.Transaction = (SqlTransaction)await dbContext.Connection.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        try
        {
            await dbContext.Transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await dbContext.Transaction.RollbackAsync(cancellationToken);
            throw;
        }
        finally
        {
            await dbContext.Transaction.DisposeAsync();
        }
    }

    public void Dispose()
    {
        dbContext.Transaction?.Dispose();
        dbContext.Transaction = null!;
        GC.SuppressFinalize(this);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        await dbContext.Transaction.RollbackAsync(cancellationToken);
    }
}
