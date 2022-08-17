using System.Data;

namespace Dapper_NOMiNiApi.SqlContext
{
    public abstract class IDapperHelper
    {
        public abstract T QueryFirst<T>(string sql, object? param = null, IDbTransaction? tran = null,
          int? commandTimeout = null, CommandType? commandType = null);


        public abstract IEnumerable<T> Query<T>(string sql, object? param = null, IDbTransaction? tran = null,
           bool buffed = true, int? commandTimeout = null, CommandType? commandType = null);
    }
}
