using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Movie.SummaryModels {

    public class Producer {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("executive")]
        public bool Executive { get; set; }

        [JsonProperty("images")]
        public HeadshotImage Images { get; set; }
    }

}