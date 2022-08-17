using Newtonsoft.Json;

namespace Dapper_NOMiNiApi.Models
{
    public class MenuModel
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("isShow")]
        public bool IsShow { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("parentid")]
        public Guid ParentId { get; set; }
    }
    public class Route {
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }


    public class Meta {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("isShow")]
        public bool IsShow { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
