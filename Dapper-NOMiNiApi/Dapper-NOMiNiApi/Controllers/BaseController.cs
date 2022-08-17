using Dapper_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dapper_NOMiNiApi.Controllers
{
    [Route("api/")]
    public class BaseController : ControllerBase
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //public BaseController(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        //protected UserModel CurrentUser
        //{
        //    get
        //    {
        //        // 通过注入的IHttpContextAccessor获取`HttpContext.User(ClaimsPrinciple)`中对应的Claims信息
        //        var UserName = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
        //        return new UserModel() { UserName = UserName??"" };
        //    }
        //}
    }
}
