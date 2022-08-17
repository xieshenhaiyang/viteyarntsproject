using System.Text;
using TouchSocket.Core;
using TouchSocket.Core.Data;
using TouchSocket.Sockets;

namespace ClassLibrary1
{
    public class MyFixedHeaderCustomDataHandlingAdapter : CustomFixedHeaderDataHandlingAdapter<MyRequestInfo>
    {
        public MyFixedHeaderCustomDataHandlingAdapter()
        {
            this.MaxPackageSize = 1024;
        }

        /// <summary>
        /// 接口实现，指示固定包头长度
        /// </summary>
        public override int HeaderLength => 15;

        public override bool CanSendRequestInfo => throw new NotImplementedException();

        /// <summary>
        /// 获取新实例
        /// </summary>
        /// <returns></returns>
        protected override MyRequestInfo GetInstance()
        {
            return new MyRequestInfo();
        }

        protected override void PreviewSend(IRequestInfo requestInfo, bool isAsync)
        {
            //throw new NotImplementedException();
        }
    }

    public class MyRequestInfo : IFixedHeaderRequestInfo
    {
        public int BodyLength { get; set; }
        public string ID { get; set; }
        public byte Type { get; set; }
        public byte[] Data { get; set; }

        public bool OnParsingBody(byte[] body)
        {
            if (body.Length == this.BodyLength)
            {
                this.Data = body.Skip(0).Take(this.BodyLength - 2).ToArray();
                byte[] crc = body.Skip(this.BodyLength - 2).Take(2).ToArray();

                byte[] crcnew = Crc.Crc16(this.Data);
                if (Enumerable.SequenceEqual(crc, crcnew))
                {
                    return true;
                }
            }
            return false;
        }

        public bool OnParsingHeader(byte[] header)
        {
            if (header.Length == 15)
            {
                ID = Encoding.ASCII.GetString(header, 0, 10);
                Type = header[10];
                this.BodyLength = (int)TouchSocketBitConverter.BigEndian.ToUInt32(header, 11) + 2;
                return true;
            }
            return false;
        }
    }
}