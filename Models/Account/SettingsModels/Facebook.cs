using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    public class Facebook {

        [JsonProperty("connected")]
        public bool Connected { get; set; }
    }

}