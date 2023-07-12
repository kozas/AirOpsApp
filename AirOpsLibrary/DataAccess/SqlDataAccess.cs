using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AirOpsLibrary.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration config;

    public SqlDataAccess(IConfiguration config)
    {
        this.config = config;
    }

    public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
    {
        string connectionString = config.GetConnectionString(connectionStringName);

        using IDbConnection connection = new SqlConnection(connectionString);

        IEnumerable<T> rows = await connection.QueryAsync<T>(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);

        return rows.ToList();
    }

    public Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
    {
        string connectionString = config.GetConnectionString(connectionStringName);

        using IDbConnection connection = new SqlConnection(connectionString);

        return connection.ExecuteAsync(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }
}

