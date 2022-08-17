using Newtonsoft.Json;

namespace Dapper_NOMiNiApi.Dto
{
    public class OrderQueryDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("cout")]
        public int Cout { get; set; }
    }
}
