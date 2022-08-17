using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Dapper_Demo.Common;
using Dapper_Demo.DAL;
using Dapper_Demo.Services;
using Dapper_Demo.SqlContext;
using Dapper_NOMiNiApi.DAL;
using Dapper_NOMiNiApi.Modules;
using Dapper_NOMiNiApi.Services;
using Dapper_NOMiNiApi.SqlContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext(builder.Configuration.GetConnectionString("Default"));
//跨域
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// 注册服务 jwt 这里有鉴权了
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true, //是否验证Issuer
        ValidIssuer = builder.Configuration["Jwt:Issuer"], //发行人Issuer
        ValidateAudience = true, //是否验证Audience
        ValidAudience = builder.Configuration["Jwt:Audience"], //订阅人Audience
        ValidateIssuerSigningKey = true, //是否验证SecurityKey
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])), //SecurityKey
        ValidateLifetime = true, //是否验证失效时间
        ClockSkew = TimeSpan.FromSeconds(30), //过期时间容错值，解决服务器端时间不同步问题（秒）
        RequireExpirationTime = true,
    };
    options.Events = new JwtBearerEvents()
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 401;
            context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiReturnModel( 401,   "授权未通过", "" )));
            return Task.CompletedTask;
        }
    };
});
/*
  policy1 要求用户拥有一个 Claim，其 ClaimType 值为 EmployeeNumber。
  policy2 要求用户拥有一个 Claim，其 ClaimType 值为 EmployeeNumber，且其 ClaimValue 值为1、2、3、4 或 5。
*/
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("policy1", policy => policy.RequireClaim("EmployeeNumber"));
//    options.AddPolicy("policy2", policy => policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
//});
// services && DAL 改成反射 todo
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<BaseUserDAL, UserDAL>();
builder.Services.AddScoped<BaseMenuDAL, MenuDAL>();
builder.Services.AddSingleton<IUser, User>();
builder.Services.AddSingleton<IMenuService, MenuService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//-------------


builder.Services.AddSingleton(new JwtHelper(builder.Configuration));
// atuomapper
// 在当前作用域的所有程序集里面扫描AutoMapper的配置文件
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IMapper, Mapper>();

// autofac就没必要了
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutoFacModuleRegister());
    });
//builder.Host.ConfigureContainer<ContainerBuilder>(builder => {
//    // builder.RegisterType<A>().As<IA>();  // 直接注册某一个类和接口,左边的是实现类，右边的As是接口
//});
builder.Services.AddScoped(typeof(DapperExtHelperBase<>),typeof(DapperExtHelper<>));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthentication();//认证
app.UseAuthorization();//授权

app.MapControllers();

app.Run();
