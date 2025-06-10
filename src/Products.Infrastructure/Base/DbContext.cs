using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;


namespace Products.Infrastructure.Base;

public class DbContext : IDisposable
{
    public SqlTransaction Transaction { get; set; }
    public SqlConnection Connection { get; set; }
    public string ConnectionString { get; set; }

    public DbContext(DbConnectionStringBuilder connectionStringBuilder)
    {
        SqlConnection(connectionStringBuilder.ToString());
        ConnectionString = connectionStringBuilder.ToString();
    }

    public DbContext(string connection)
    {
        SqlConnection(connection);
        ConnectionString = connection;
    }

    private void SqlConnection(string conectionString)
    {
        if (Connection is not null && (Connection.State & ConnectionState.Open) != 0)
            return;

        Connection = new SqlConnection(conectionString);
    }

    public void Dispose()
    {
        Transaction?.Dispose();
        Connection?.Close();
        Connection?.Dispose();

        GC.SuppressFinalize(this);
    }
}
