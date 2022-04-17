
using Internal.Audit.Domain.Common;

namespace Internal.Audit.Application.Contracts.Persistent;

public interface IAsyncQueryRepository<TEntity> where TEntity : EntityBase
{
    Task<IEnumerable<TEntity>> Get(string query, bool isProcedure = false);
    Task<IEnumerable<TEntity>> Get(string query, Dictionary<string, object> parameters, bool isProcedure = false);
    Task<TEntity> Single(string query, bool isProcedure = false);
    Task<TEntity> Single(string query, Dictionary<string, object> parameters, bool isProcedure = false);
    
    Task<IEnumerable<TEntity>> Get<TFirst, TSecond, TEntity>(string sql, Func<TFirst, TSecond, TEntity> map, Dictionary<string, object> parameters, string splitters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TEntity : class;

    Task<IEnumerable<TEntity>> Get<TFirst, TSecond, TThird, TEntity>(string sql, Func<TFirst, TSecond, TThird, TEntity> map, Dictionary<string, object> parameters, string splitters, bool isProcedure = false)
          where TFirst : class
          where TSecond : class
          where TThird : class
          where TEntity : class;

    Task<IEnumerable<TEntity>> Get<TFirst, TSecond, TThird,TFourth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TEntity> map, Dictionary<string, object> parameters, string splitters, bool isProcedure = false)
      where TFirst : class
      where TSecond : class
      where TThird : class
      where TFourth : class
      where TEntity : class;

    Task<IEnumerable<TEntity>> Get<TFirst, TSecond, TThird, TFourth,TFifth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> map, Dictionary<string, object> parameters, string splitters, bool isProcedure = false)
     where TFirst : class
     where TSecond : class
     where TThird : class
     where TFourth : class
     where TFifth : class
     where TEntity : class;
}
