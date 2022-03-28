
using Dapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Domain.Common;
using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Internal.Audit.Infrastructure.Persistent.Repositories;

public class QueryRepositoryBase<TEntity> : IAsyncQueryRepository<TEntity> where TEntity : EntityBase
{
    protected readonly string _connectionString;

    public QueryRepositoryBase(string _connectionString)
    {
        this._connectionString = _connectionString;
    }
    public async Task<IEnumerable<TEntity>> Get(string query, bool isProcedure = false)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return await connection.QueryAsync<TEntity>(query, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text);

    }

    public async Task<IEnumerable<TEntity>> Get(string query, Dictionary<string, object> parameters, bool isProcedure = false)
    {
        var dynamicParameters = new DynamicParameters();
        foreach(var param in parameters) dynamicParameters.Add(param.Key, param.Value);

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return await connection.QueryAsync<TEntity>(query, dynamicParameters, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text);
    }

    public async Task<TEntity> Single(string query, bool isProcedure = false)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return await connection.QueryFirstOrDefaultAsync<TEntity>(query, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text);
    }

    public async Task<TEntity> Single(string query, Dictionary<string, object> parameters, bool isProcedure = false)
    {
        var dynamicParameters = new DynamicParameters();
        foreach (var param in parameters) dynamicParameters.Add(param.Key, param.Value);

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return await connection.QueryFirstOrDefaultAsync<TEntity>(query, dynamicParameters, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text);
    }
}
