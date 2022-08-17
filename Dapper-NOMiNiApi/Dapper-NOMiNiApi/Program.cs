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
//����
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
// ע����� jwt �����м�Ȩ��
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true, //�Ƿ���֤Issuer
        ValidIssuer = builder.Configuration["Jwt:Issuer"], //������Issuer
        ValidateAudience = true, //�Ƿ���֤Audience
        ValidAudience = builder.Configuration["Jwt:Audience"], //������Audience
        ValidateIssuerSigningKey = true, //�Ƿ���֤SecurityKey
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])), //SecurityKey
        ValidateLifetime = true, //�Ƿ���֤ʧЧʱ��
        ClockSkew = TimeSpan.FromSeconds(30), //����ʱ���ݴ�ֵ�������������ʱ�䲻ͬ�����⣨�룩
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
            context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiReturnModel( 401,   "��Ȩδͨ��", "" )));
            return Task.CompletedTask;
        }
    };
});
/*
  policy1 Ҫ���û�ӵ��һ�� Claim���� ClaimType ֵΪ EmployeeNumber��
  policy2 Ҫ���û�ӵ��һ�� Claim���� ClaimType ֵΪ EmployeeNumber������ ClaimValue ֵΪ1��2��3��4 �� 5��
*/
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("policy1", policy => policy.RequireClaim("EmployeeNumber"));
//    options.AddPolicy("policy2", policy => policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
//});
// services && DAL �ĳɷ��� todo
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<BaseUserDAL, UserDAL>();
builder.Services.AddScoped<BaseMenuDAL, MenuDAL>();
builder.Services.AddSingleton<IUser, User>();
builder.Services.AddSingleton<IMenuService, MenuService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//-------------


builder.Services.AddSingleton(new JwtHelper(builder.Configuration));
// atuomapper
// �ڵ�ǰ����������г�������ɨ��AutoMapper�������ļ�
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IMapper, Mapper>();

// autofac��û��Ҫ��
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutoFacModuleRegister());
    });
//builder.Host.ConfigureContainer<ContainerBuilder>(builder => {
//    // builder.RegisterType<A>().As<IA>();  // ֱ��ע��ĳһ����ͽӿ�,��ߵ���ʵ���࣬�ұߵ�As�ǽӿ�
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
app.UseAuthentication();//��֤
app.UseAuthorization();//��Ȩ

app.MapControllers();

app.Run();
