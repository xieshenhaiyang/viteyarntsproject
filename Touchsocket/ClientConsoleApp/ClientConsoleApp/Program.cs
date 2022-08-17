using ClassLibrary1;
using System.Text;
using TouchSocket.Core.Config;
using TouchSocket.Sockets;

TcpClient tcpClient = new TcpClient();
tcpClient.Connected += (client, e) => { };//成功连接到服务器
tcpClient.Disconnected += (client, e) => { };//从服务器断开连接，当连接不成功时不会触发。
tcpClient.Received += (client, byteBlock, requestInfo) =>
{
    //从服务器收到信息
    string mes = Encoding.UTF8.GetString(byteBlock.Buffer, 0, byteBlock.Len);
    Console.WriteLine($"接收到信息：{mes}");
};

//声明配置
TouchSocketConfig config = new TouchSocketConfig();
config.SetRemoteIPHost(new IPHost("127.0.0.1:7789"))
    .UsePlugin()
    .SetDataHandlingAdapter(() => new MyFixedHeaderCustomDataHandlingAdapter())//new FixedHeaderPackageAdapter())
    .SetBufferLength(1024 * 10);

//载入配置
tcpClient.Setup(config);
tcpClient.Connect();
while (true) {
    Console.ReadKey();
    for (int i = 0; i < 100; i++)
    {
        tcpClient.Send("touchSocket");
    }
    //tcpClient.Send(Console.ReadLine());
}
//tcpClient.Send("RRQM");