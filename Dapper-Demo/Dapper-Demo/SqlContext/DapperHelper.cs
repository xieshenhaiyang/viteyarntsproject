using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Dapper_Demo.SqlContext
{
    public class DapperHelper
    {
        private IDbConnection _dbConnection = new SqlConnection();
        public string ConnectionString => DbContext.ConnectingStr;
        public DapperHelper() {
            _dbConnection.ConnectionString = ConnectionString;
        }

        public T QueryFirst<T>(string sql, object? param = null, IDbTransaction? tran = null,
           int? commandTimeout = null, CommandType? commandType = null)
        {
            return _dbConnection.QueryFirst<T>(sql, param, tran, commandTimeout, commandType);
        }

        public IEnumerable<T> Query<T>(string sql, object? param = null, IDbTransaction? tran = null,
           bool buffed = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return _dbConnection.Query<T>(sql, param, tran, buffed, commandTimeout, commandType);
        }

    }
}
