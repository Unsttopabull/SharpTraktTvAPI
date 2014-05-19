using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    public class Prowl {

        [JsonProperty("connected")]
        public bool Connected { get; set; }
    }

}