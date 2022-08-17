using Autofac;
using AutoMapper;
using Dapper_Demo.Common;
using Dapper_Demo.DAL;
using Dapper_NOMiNiApi.mapper;
using Dapper_NOMiNiApi.SqlContext;
using System.Reflection;

namespace Dapper_NOMiNiApi.Modules
{
    public class AutoFacModuleRegister : Autofac.Module
    {
        // 重写AutoFac管道Load方法，在这里注册注入
        protected override void Load(ContainerBuilder builder)
        {
            //程序集注入业务服务
            //var IAppServices = Assembly.Load("Application");
            //var AppServices = Assembly.Load("Application");
            //根据名称约定（服务层的接口和实现均以Service结尾），实现服务接口和服务实现的依赖
            //builder.RegisterAssemblyTypes(IAppServices, AppServices)
            //  .Where(t => t.Name.EndsWith("Service"))
            //  .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(DapperExtHelper<>)).As(typeof(DapperExtHelperBase<>)).InstancePerDependency();
        }
    }
}
