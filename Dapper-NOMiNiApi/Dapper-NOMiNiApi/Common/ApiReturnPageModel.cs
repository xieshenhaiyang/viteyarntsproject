using Newtonsoft.Json;

namespace Dapper_Demo.Common
{
    public class ApiReturnPageModel
    {
        public ApiReturnPageModel(int code, string message, object data, int currentPage, int count)
        {
            Code = code;
            Message = message;
            Data = data;
            CurrentPage = currentPage;
            Count = count;
        }

        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public object Data { get; set; }
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; } = 1;
        [JsonProperty("count")]
        public int Count { get; set; } = 10;
    }
}
