using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    [JsonObject(Title = "Account")]
    public class AccountSettings {

        [JsonProperty("timezone")]
        public string Timezone { get; set; } ////go.trakt.tv/HX7SfQ

        [JsonProperty("use_24hr")]
        public bool Use24Hr { get; set; }

        [JsonProperty("protected")]
        public bool IsProtected { get; set; }
    }

}