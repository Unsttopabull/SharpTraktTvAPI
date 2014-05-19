using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Movie.SummaryModels {

    public class Ratings {

        [JsonProperty("percentage")]
        public int Percentage { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }

        [JsonProperty("loved")]
        public int Loved { get; set; }

        [JsonProperty("hated")]
        public int Hated { get; set; }
    }

}