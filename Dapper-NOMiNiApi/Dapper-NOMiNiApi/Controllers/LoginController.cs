using AutoMapper;
using Dapper_Demo.Common;
using Dapper_Demo.DAL;
using Dapper_Demo.Models;
using Dapper_Demo.Services;
using Dapper_NOMiNiApi;
using Dapper_NOMiNiApi.Common;
using Dapper_NOMiNiApi.Controllers;
using Dapper_NOMiNiApi.Dto;
using Dapper_NOMiNiApi.Entity;
using Dapper_NOMiNiApi.Extensions;
using Dapper_NOMiNiApi.Services;
using Dapper_NOMiNiApi.SqlContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dapper_Demo.Controllers
{
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly IUserService _userService;
        private readonly JwtHelper _jwtHelper;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public LoginController(IUserService userService,
            JwtHelper jwtHelper, IMapper mapper, IUser user)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
            _mapper = mapper;
            _user = user;
        }

        [AllowAnonymous]
        [HttpPost,Route("login")]
        public ApiReturnModel Get([FromBody] UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return new ApiReturnModel(200, "Invalid Request", "");
            }
            var rt = _userService.GetUserByLogin(userLoginDto.UserName, userLoginDto.PassWord);
            if (rt != null)
            {
                //TokenModelJwt tokenModel = new TokenModelJwt { UserId = user.Id.ToString(), CreateDept = "测试部门" };
                Dictionary<string, string> data = new Dictionary<string, string>();
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
                claims.Add(new Claim(ClaimTypes.Role, "admin2"));
                return new ApiReturnModel(200, "", new { token = _jwtHelper.CreateToken(claims), });
            }
            return new ApiReturnModel(500, "", "");
        }

        /// <summary>
        /// 刷新Token（以旧换新）
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<dynamic> RefreshToken(string token)
        //{
        //    return null;
        //    //ApiReturnModel dXResult = new ApiReturnModel(200, "刷新成功", "");
        //    //string jwtStr = string.Empty;
        //    //var userInfo = JwtHelper.SerializeJwt(token);
        //    //if (userInfo == null)
        //    //{
        //    //    return new ApiReturnModel(500, "无效token", "");
        //    //}
        //    //var refreshExpires = userInfo?.RefreshExpires;
        //    //if (!refreshExpires.IsNotEmptyOrNull())
        //    //{
        //    //    return new ApiReturnModel(500, "无效刷新时间", ""); //new DXResult { code = DXCode.Failure, msg = "无效刷新时间" };
        //    //}

        //    //if (refreshExpires.ObjToLong() <= DateTime.Now.ObjToTimestamp())
        //    //{
        //    //    return new ApiReturnModel(500, "登录信息已过期", "");// new DXResult { code = DXCode.Failure, msg = "登录信息已过期" };
        //    //}

        //    //var userId = userInfo?.UserId;
        //    //if (!userId.IsNotEmptyOrNull())
        //    //{
        //    //    return new DXResult { code = DXCode.Failure, msg = "用户信息为空" };
        //    //}
        //    //var dXResultUser = await _systemUserBLL.TokenGetById(userId.ObjToLong());
        //    //if (dXResultUser.code != DXCode.Success)
        //    //{
        //    //    return new DXResult { code = DXCode.Failure, msg = "获取用户信息失败" };
        //    //}
        //    //var userObj = dXResultUser.data as SystemUser;
        //    //TokenModelJwt tokenModel = new TokenModelJwt { UserId = userObj.Id.ToString(), CreateDept = "测试刷新部门" };
        //    //jwtStr = JwtHelper.IssueJwt(tokenModel);
        //    //dXResult.data = jwtStr;
        //    //return dXResult;
        //}

        /// <summary>
        /// 测试获取登录用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetUserTest")]
        [Authorize]
        public ApiReturnModel GetUserTest()
        {
            var userObj = new
            {
                id = _user.Id,
                dept = _user.CreateDept
            };
            return new ApiReturnModel(200, "", userObj);
        }

        [HttpPost("orders")]
        [Authorize(Roles = "admin")]
        public ApiReturnPageModel GetOrders([FromBody] OrderQueryDto orderQueryDto)
        {
            var rt = _userService.GetOrders(orderQueryDto.Title, orderQueryDto.Body, orderQueryDto.Page, orderQueryDto.Cout);
            return new ApiReturnPageModel(200, "", rt.Item2, 1, rt.Item1);
        }


        [Authorize]
        // Policy策略 推荐的授权方式，在 ASP.NET Core 的官方文档提及最多的。
        // 一个 Policy 可以包含多个要求（要求可能是 Role 匹配，也可能是 Claims 匹配，也可能是其他方式。）
        [Authorize(Roles = "admin", AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public ActionResult<string> GetTest()
        {
            return "Test Authorize";
        }
    }
}
