using Blog.Entity;
using Blog.IRepository;
using System;
using System.Reflection;

namespace Blog.Common
{
    /// <summary>
    /// ServiceCollection扩展
    /// </summary>
    public static class ServiceCollectionExtension
    {
        public static void AddScopeIOC(this IServiceCollection services)
        {
            // 注册服务
            var RepoInterface = typeof(IBaseRepository<BaseId>).Assembly;
            var RepoClass = typeof(BaseRepository<BaseId>).Assembly;
            services.AddTransientExtension

            // 注册仓储



        }
        /// <summary>
        /// 批量注入
        /// </summary>
        /// <param name="services">扩张对象</param>
        /// <param name="interfaceAssembly">接口</param>
        /// <param name="implementAssembly">实现类</param>
        public static void AddTransient(IServiceCollection services , Assembly interfaceAssembly, Assembly implementAssembly)
        {
            var interfaces = interfaceAssembly.GetTypes().Where(t => t.IsInterface);//拿到项目中所有接口
            var implements = implementAssembly.GetTypes();//拿到项目中所有类和接口
            foreach (var item in interfaces)
            { 
                //判断是否实现了该接口,实现了就直接注入
                var type = implements.FirstOrDefault(x => item.IsAssignableFrom(x));
                if (type != null)
                {
                    services.AddTransient(item, type);
                }
            }
        }
    }
}
