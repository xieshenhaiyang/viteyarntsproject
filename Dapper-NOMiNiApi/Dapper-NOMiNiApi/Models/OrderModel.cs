using Dapper.Contrib.Extensions;
using Newtonsoft.Json;

namespace Dapper_NOMiNiApi.Models
{
    public class OrderModel
    {
        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
