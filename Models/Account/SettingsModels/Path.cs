using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    public class Path {

        [JsonProperty("connected")]
        public bool Connected { get; set; }
    }

}