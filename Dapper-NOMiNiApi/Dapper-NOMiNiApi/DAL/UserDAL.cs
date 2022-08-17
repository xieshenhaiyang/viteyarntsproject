using Dapper_Demo.Models;
using Dapper_Demo.SqlContext;
using Dapper_NOMiNiApi.Entity;
using Dapper_NOMiNiApi.SqlContext;

namespace Dapper_Demo.DAL
{
    public class UserDAL : BaseUserDAL
    {
        private readonly IDapperHelper _dapperHelper;
        public UserDAL(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public override UserEntity GetUserByLogin(string userName, string passWord)
        {
            string sql = "select * from Users where UserName = @UserName and Password = @Password";
            var rt = _dapperHelper.QueryFirst<UserEntity>(sql, new { UserName = userName, Password = passWord });
            return rt;
        }

        public override (int count,IEnumerable<OrderEntity>) GetOrders(string title, string body, int page, int count)
        {
            string sql = @"SELECT   [OrderId]
      ,[Id]
      ,[Title]
      ,[Body]
  FROM[Dapper].[dbo].[Orders]
where Title like '%'+@title+'%'
and Body like '%'+@body+'%'
order by Id";
            string sqlFY = @"SELECT   [OrderId]
      ,[Id]
      ,[Title]
      ,[Body]
  FROM[Dapper].[dbo].[Orders]
where Title like '%'+@title+'%'
and Body like '%'+@body+'%'
order by Id
offset (@page - 1)*@count rows
fetch next @count rows only";
            var rt1 = _dapperHelper.Query<OrderEntity>(sql, new { title=title, body=body });
            var rt2 = _dapperHelper.Query<OrderEntity>(sqlFY, new { title=title, body=body,page = page,count=count });
            return (rt1.Count(), rt2);
        }
    }
}
