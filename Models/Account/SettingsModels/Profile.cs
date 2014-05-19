using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account.SettingsModels {

    public class Profile {

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("joined")]
        public int Joined { get; set; }

        [JsonProperty("last_login")]
        public int LastLogin { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("vip")]
        public bool Vip { get; set; }
    }

}