using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    public class Twitter {
        [JsonProperty("connected")]
        public bool Connected { get; set; }
    }

}