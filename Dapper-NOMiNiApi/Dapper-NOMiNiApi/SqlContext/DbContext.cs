using Dapper_NOMiNiApi.SqlContext;
using System.Data;
using System.Data.SqlClient;

namespace Dapper_Demo.SqlContext
{
    public static class DbContext
    {
        private static IDbConnection _dbConnection = new SqlConnection();

        public static IDbConnection DbConnection
        {
            get {
                if (string.IsNullOrEmpty(_dbConnection.ConnectionString))
                {
                    _dbConnection.ConnectionString = ConnectionString;
                }
                return _dbConnection; 
            }
        }

        private static string? _connectionString;
        public static string? ConnectionString
        {
            get { 
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            ConnectionString = connectionString;
            services.AddScoped<IDapperHelper, DapperHelper>();
        }
    }
}
