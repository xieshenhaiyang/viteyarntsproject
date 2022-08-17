using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Dapper_NOMiNiApi.SqlContext;

namespace Dapper_Demo.SqlContext
{
    public class DapperHelper : IDapperHelper
    {
        private IDbConnection _dbConnection = DbContext.DbConnection;

        public override T QueryFirst<T>(string sql, object? param = null, IDbTransaction? tran = null,
           int? commandTimeout = null, CommandType? commandType = null)
        {
            return _dbConnection.QueryFirst<T>(sql, param, tran, commandTimeout, commandType);
        }

        public override IEnumerable<T> Query<T>(string sql, object? param = null, IDbTransaction? tran = null,
           bool buffed = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return _dbConnection.Query<T>(sql, param, tran, buffed, commandTimeout, commandType);
        }

    }
}
