using AutoMapper;
using Dapper_Demo.Models;
using Dapper_NOMiNiApi.Entity;
using Dapper_NOMiNiApi.Models;

namespace Dapper_NOMiNiApi.mapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, UserEntity>();

            CreateMap<OrderEntity, OrderModel>();
        }
    }
}
