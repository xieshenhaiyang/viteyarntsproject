namespace Dapper_NOMiNiApi.Services
{

    /// <summary>
    /// 用户信息接口
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 用户名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 创建部门
        /// </summary>
        string CreateDept { get; }

    }
}
