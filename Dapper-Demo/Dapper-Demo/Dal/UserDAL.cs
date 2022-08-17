using Dapper_Demo.Models;
using Dapper_Demo.SqlContext;

namespace Dapper_Demo.Dal
{
    public class UserDAL
    {
        DapperHelper _db = new DapperHelper();

        public Users GetUserByLogin(string userName, string passWord) 
        {
            string sql = "select * from Users where UserName = @UserName and Password = @Password";
            var rt = _db.QueryFirst<Users>(sql, new { UserName = userName, Password = passWord });
            return rt;
        }
    }
}
