using Newtonsoft.Json;
namespace WatchListDTOs
{
    public class UserAuthData
    {
        [JsonProperty(PropertyName = "uid")]
        public string UID { get; set; }

        [JsonProperty(PropertyName = "pass")]
        public string Password { get; set; }
    }

}
