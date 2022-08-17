using Dapper_Demo.Common;
using Dapper_Demo.Models;
using Dapper_Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Demo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet("{userName}/{password}")]
        public ApiReturnModel Get([FromBody]string userName,string password) {
            UserService service = new UserService();
            var rt = service.GetUserByLogin(userName, password);
            if (rt != null)
            {
                return new ApiReturnModel(200, "", "");
            }
            return new ApiReturnModel(500, "", "");
        }
    }
}
