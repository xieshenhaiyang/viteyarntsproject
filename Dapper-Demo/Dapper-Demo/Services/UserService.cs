using Dapper_Demo.Dal;
using Dapper_Demo.Models;

namespace Dapper_Demo.Services
{
    public class UserService
    {
        UserDAL _da = new UserDAL();
        public Users GetUserByLogin(string userName,string password) { 
            return _da.GetUserByLogin(userName,password);
        }
    }
}
