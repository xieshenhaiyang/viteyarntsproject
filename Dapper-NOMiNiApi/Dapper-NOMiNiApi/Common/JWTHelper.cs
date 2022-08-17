using Dapper_NOMiNiApi.Common;
using Dapper_NOMiNiApi.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dapper_Demo.Common;

public class JwtHelper
{
    private readonly IConfiguration _configuration;

    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public string CreateToken(List<Claim> claims)
    {
        //// 1. 定义需要使用到的Claims
        //var claims = new[]
        //{
        //    new Claim(ClaimTypes.Name, @"admin"), //HttpContext.User.Identity.Name
        //    new Claim(ClaimTypes.Role, @"admin"), //HttpContext.User.IsInRole("r\_admin")
        //    new Claim(JwtRegisteredClaimNames.Jti, "admin"),
        //    new Claim("Username", "Admin"),
        //    new Claim("Name", "超级管理员")
        //};
        // 2. 从 appsettings.json 中读取SecretKey
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        // 3. 选择加密算法
        var algorithm = SecurityAlgorithms.HmacSha256;
        // 4. 生成Credentials
        var signingCredentials = new SigningCredentials(secretKey, algorithm);
        // 5. 根据以上，生成token
        var jwtSecurityToken = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],     //Issuer
            _configuration["Jwt:Audience"],   //Audience
            claims,                          //Claims,
            DateTime.Now,                    //notBefore
            DateTime.Now.AddSeconds(230),    //expires
            signingCredentials               //Credentials
        );
        // 6. 将token变为string
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return token;
    }

    /// <summary>
    /// 解析
    /// </summary>
    /// <param name="jwtStr"></param>
    /// <returns></returns>
    public static TokenModelJwt SerializeJwt(string jwtStr)
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        TokenModelJwt tokenModelJwt = new TokenModelJwt();

        // token校验
        if (jwtStr.IsNotEmptyOrNull() && jwtHandler.CanReadToken(jwtStr))
        {

            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);

            Claim[] claimArr = jwtToken?.Claims?.ToArray();
            if (claimArr != null && claimArr.Length > 0)
            {
                tokenModelJwt.UserId = claimArr.FirstOrDefault(a => a.Type == ClaimAttributes.UserId)?.Value;
                tokenModelJwt.RefreshExpires = claimArr.FirstOrDefault(a => a.Type == ClaimAttributes.RefreshExpires)?.Value;
                tokenModelJwt.CreateDept = claimArr.FirstOrDefault(a => a.Type == ClaimAttributes.CreateDept)?.Value;
            }
        }
        return tokenModelJwt;
    }


}
/// <summary>
/// 令牌
/// </summary>
public class TokenModelJwt
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public string UserId { get; set; }
    /// <summary>
    /// 所属部门
    /// </summary>
    public string CreateDept { get; set; }
    /// <summary>
    /// 刷新有效时间
    /// </summary>
    public string RefreshExpires { get; set; }

}
