using Newtonsoft.Json;

namespace Dapper_Demo.Common
{
    public class ApiReturnModel
    {
        public ApiReturnModel(int code, string message, string data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
