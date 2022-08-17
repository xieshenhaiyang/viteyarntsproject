using Newtonsoft.Json;

namespace Dapper_NOMiNiApi
{
    public class UserLoginDto
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("passWord")]
        public string PassWord { get; set; }
    }
}
