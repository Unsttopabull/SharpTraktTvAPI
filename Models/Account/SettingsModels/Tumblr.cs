using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    public class Tumblr {

        [JsonProperty("connected")]
        public bool Connected { get; set; }
    }

}