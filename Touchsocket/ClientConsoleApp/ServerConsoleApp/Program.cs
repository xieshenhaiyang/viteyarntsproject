using ClassLibrary1;
using System.Text;
using TouchSocket.Core.Config;
using TouchSocket.Core.Dependency;
using TouchSocket.Core.Log;
using TouchSocket.Sockets;

TcpService service = new TcpService();
service.Connecting += (client, e) => { };//有客户端正在连接
service.Connected += (client, e) => { };//有客户端连接
service.Disconnected += (client, e) => { };//有客户端断开连接
service.Received += (client, byteBlock, requestInfo) =>
{
    //从客户端收到信息
    string mes = Encoding.UTF8.GetString(byteBlock.Buffer, 0, byteBlock.Len);
    Console.WriteLine($"已从{client.ID}接收到信息：{mes}");

    client.Send(mes);//将收到的信息直接返回给发送方

    //client.Send("id",mes);//将收到的信息返回给特定ID的客户端

    var clients = service.GetClients();
    foreach (var targetClient in clients)//将收到的信息返回给在线的所有客户端。
    {
        if (targetClient.ID != client.ID)
        {
            targetClient.Send(mes);
        }
    }
};

service.Setup(new TouchSocketConfig()//载入配置     
    .SetListenIPHosts(new IPHost[] { new IPHost("127.0.0.1:7789"), new IPHost(7790) })//同时监听两个地址
    .SetMaxCount(10000)
    .SetDataHandlingAdapter(() => new MyFixedHeaderCustomDataHandlingAdapter() )//new FixedHeaderPackageAdapter())
    .SetThreadCount(10)
    .ConfigurePlugins(a =>
    {
        //a.Add();//此处可以添加插件
    })
    .ConfigureContainer(a =>
    {
        a.SetSingletonLogger<TouchSocket.Core.Log.ConsoleLogger>();//添加一个日志注入
    }))
    .Start();//启动

service.Logger.Message(msg: "服务器已启动！");
Console.ReadKey();