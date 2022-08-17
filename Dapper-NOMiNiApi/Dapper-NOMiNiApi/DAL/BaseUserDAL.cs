using Dapper_Demo.SqlContext;
using Dapper_NOMiNiApi.DAL;
using Dapper_NOMiNiApi.Entity;
using Dapper_NOMiNiApi.SqlContext;

namespace Dapper_Demo.DAL
{
    public abstract class BaseUserDAL : BaseDAL<UserEntity>  
    {
        public abstract UserEntity GetUserByLogin(string userName, string passWord);
        public abstract (int count, IEnumerable<OrderEntity>) GetOrders(string title, string body, int page, int count);
    }
}
