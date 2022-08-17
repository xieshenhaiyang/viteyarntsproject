using Dapper_Demo.Common;
using Dapper_NOMiNiApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_NOMiNiApi.Controllers
{
    [ApiController]
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet, Route("menus")]
        [Authorize(Roles = "admin")]
        public ApiReturnModel GetAllMenus() 
        {
            return new ApiReturnModel(200, "成功", _menuService.GetMenus());
        }
    }
}
