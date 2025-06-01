using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Products.Infrastructure.Scripts;

public class RepositoryBase(IConfiguration configuration) : IDisposable
{
    private readonly IDbConnection _conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

    public IDbConnection Connection
    {
        get
        {
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }

            return _conn;
        }
    }


    public void Dispose()
    {
        _conn?.Dispose();
    }

}
