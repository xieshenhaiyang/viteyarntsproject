using Dapper_Demo.Models;
using Dapper_NOMiNiApi.Models;

namespace Dapper_NOMiNiApi.Services
{
    public interface IUserService
    {
        UserModel GetUserByLogin(string userName, string password);
        (int count, IEnumerable<OrderModel>) GetOrders(string title, string body, int page, int count);
    }
}
