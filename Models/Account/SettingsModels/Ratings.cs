using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    public class Ratings {

        [JsonProperty("mode")]
        public string Mode { get; set; }
    }

}