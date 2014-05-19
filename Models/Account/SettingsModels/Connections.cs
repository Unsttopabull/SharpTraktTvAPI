using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    public class Connections {

        [JsonProperty("facebook")]
        public Facebook Facebook { get; set; }

        [JsonProperty("twitter")]
        public Twitter Twitter { get; set; }

        [JsonProperty("tumblr")]
        public Tumblr Tumblr { get; set; }

        [JsonProperty("path")]
        public Path Path { get; set; }

        [JsonProperty("prowl")]
        public Prowl Prowl { get; set; }
    }

}