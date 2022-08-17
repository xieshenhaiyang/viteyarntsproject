using Dapper_NOMiNiApi.Common;
using Dapper_NOMiNiApi.Extensions;

namespace Dapper_NOMiNiApi.Services
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public User(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        /// 用户Id
        /// </summary>
        public virtual string Id
        {
            get
            {
                var id = _accessor?.HttpContext?.User?.FindFirst(ClaimAttributes.UserId);
                if (id != null && id.Value.IsNotEmptyOrNull())
                {
                    return id.Value;
                }
                return "";
            }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            get
            {
                var name = _accessor?.HttpContext?.User?.FindFirst(ClaimAttributes.UserName);

                if (name != null && name.Value.IsNotEmptyOrNull())
                {
                    return name.Value;
                }

                return "";
            }
        }

        /// <summary>
        /// 创建部门
        /// </summary>
        public string CreateDept
        {
            get
            {
                var name = _accessor?.HttpContext?.User?.FindFirst(ClaimAttributes.CreateDept);

                if (name != null && name.Value.IsNotEmptyOrNull())
                {
                    return name.Value;
                }

                return "";
            }
        }
    }
}