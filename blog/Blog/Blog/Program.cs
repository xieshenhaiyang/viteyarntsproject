using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlSugar(new IocConfig()
{
    //ConfigId="db01"  ���⻧�õ�
    ConnectionString = builder.Configuration.GetConnectionString("Default"),  
    DbType = IocDbType.SqlServer,
    IsAutoCloseConnection = true//�Զ��ͷ�
});; //�����ʹ�List<IocConfig>

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
