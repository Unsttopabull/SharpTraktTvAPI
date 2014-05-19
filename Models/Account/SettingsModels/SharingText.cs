using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    [JsonObject(Title = "Sharing_Text")]
    public class SharingText {

        [JsonProperty("watching")]
        public string Watching { get; set; }

        [JsonProperty("watched")]
        public string Watched { get; set; }
    }

}