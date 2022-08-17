using AutoMapper;
using Dapper_Demo.DAL;
using Dapper_Demo.Models;
using Dapper_NOMiNiApi.Models;
using Dapper_NOMiNiApi.Services;

namespace Dapper_Demo.Services
{
    public class UserService: IUserService
    {
        private readonly BaseUserDAL _baseUserDAL;
        private readonly IMapper _mapper;
        public UserService(BaseUserDAL baseUserDAL, IMapper mapper)
        {
            _baseUserDAL = baseUserDAL;
            _mapper = mapper;
        }

        public UserModel GetUserByLogin(string userName, string password)
        {
            return _mapper.Map<UserModel>(_baseUserDAL.GetUserByLogin(userName, password));
        }


        public (int count,IEnumerable<OrderModel>) GetOrders(string title, string body, int page, int count)
        {
            var rt = _baseUserDAL.GetOrders(title, body, page, count);
            return (rt.Item1,_mapper.Map<IEnumerable<OrderModel>>(rt.Item2));
        }
    }
}
