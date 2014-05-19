using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    public class Viewing {

        [JsonProperty("ratings")]
        public Ratings Ratings { get; set; } ////simple,advanced

        [JsonProperty("shouts")]
        public Shouts Shouts { get; set; }
    }

}