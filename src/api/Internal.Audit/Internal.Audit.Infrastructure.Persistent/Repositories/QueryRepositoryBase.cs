﻿
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

    public async Task<(long, IEnumerable<TEntity>)> GetWithPagingInfo(string query, Dictionary<string, object> parameters, bool isProcedure = false)
    {
        var dynamicParameters = new DynamicParameters();
        foreach (var param in parameters) dynamicParameters.Add(param.Key, param.Value);

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var grid = await connection.QueryMultipleAsync(query, dynamicParameters, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text);
        var result = (await grid.ReadAsync<TEntity>()).ToList();
        var count = (await grid.ReadAsync<long>()).First();
        return (count, result);
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

    public async Task<IEnumerable<TEntity>> Get<TFirst, TSecond, TEntity>(string sql, Func<TFirst, TSecond, TEntity> map, Dictionary<string, object> parameters, string splitters, bool isProcedure = false) where TFirst : class where TSecond : class where TEntity : class
    {
        var dynamicParameters = new DynamicParameters();
        foreach (var param in parameters) dynamicParameters.Add(param.Key, param.Value);

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return (IEnumerable<TEntity>)await connection.QueryAsync<TFirst, TSecond, TEntity>(sql, map, parameters, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text, splitOn: splitters);

    }

    public async Task<IEnumerable<TEntity>> Get<TFirst, TSecond, TThird, TEntity>(string sql, Func<TFirst, TSecond, TThird, TEntity> map, Dictionary<string, object> parameters, string splitters, bool isProcedure = false)
        where TFirst : class
        where TSecond : class
        where TThird : class
        where TEntity : class
    {
        var dynamicParameters = new DynamicParameters();
        foreach (var param in parameters) dynamicParameters.Add(param.Key, param.Value);

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return (IEnumerable<TEntity>)await connection.QueryAsync<TFirst, TSecond, TThird, TEntity>(sql, map, parameters, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text, splitOn: splitters);

    }

    public async Task<IEnumerable<TEntity>> Get<TFirst, TSecond, TThird, TFourth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TEntity> map, Dictionary<string, object> parameters, string splitters, bool isProcedure = false)
        where TFirst : class
        where TSecond : class
        where TThird : class
        where TFourth : class
        where TEntity : class
    {
        var dynamicParameters = new DynamicParameters();
        foreach (var param in parameters) dynamicParameters.Add(param.Key, param.Value);

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return (IEnumerable<TEntity>)await connection.QueryAsync<TFirst, TSecond,TThird,TFourth, TEntity>(sql, map, parameters, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text, splitOn: splitters);

    }

    public async Task<IEnumerable<TEntity>> Get<TFirst, TSecond, TThird, TFourth,TFifth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> map, Dictionary<string, object> parameters, string splitters, bool isProcedure = false)
       where TFirst : class
       where TSecond : class
       where TThird : class
       where TFourth : class
       where TFifth : class
       where TEntity : class
    {
        var dynamicParameters = new DynamicParameters();
        foreach (var param in parameters) dynamicParameters.Add(param.Key, param.Value);

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return (IEnumerable<TEntity>)await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth , TEntity>(sql, map, parameters, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text, splitOn: splitters);

    }

    public async Task<IEnumerable<TEntity>> Get<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, Dictionary<string, object> parameters, string splitters, bool isProcedure = false)
        where TFirst : class
        where TSecond : class
        where TThird : class
        where TFourth : class
        where TFifth : class
        where TSixth : class
        where TEntity : class
    {
        var dynamicParameters = new DynamicParameters();
        foreach (var param in parameters) dynamicParameters.Add(param.Key, param.Value);

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return (IEnumerable<TEntity>)await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth,TSixth, TEntity>(sql, map, parameters, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text, splitOn: splitters);

    }

    public async Task<IEnumerable<TEntity>> Get<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, Dictionary<string, object> parameters, string splitters, bool isProcedure = false)
        where TFirst : class
        where TSecond : class
        where TThird : class
        where TFourth : class
        where TFifth : class
        where TSixth : class
        where TSeventh : class
        where TEntity : class
    {
        var dynamicParameters = new DynamicParameters();
        foreach (var param in parameters) dynamicParameters.Add(param.Key, param.Value);

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return (IEnumerable<TEntity>)await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth,TSixth,TSeventh, TEntity>(sql, map, parameters, commandType: isProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text, splitOn: splitters);

    }
}
