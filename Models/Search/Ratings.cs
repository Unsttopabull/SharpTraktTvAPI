using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Search {

    /// <summary>Represents the rating info of a Trakt.TV movie.</summary>
    public class Ratings {

        /// <summary>The rating on the integer scale from 0-100</summary>
        [JsonProperty("percentage")]
        public int Percentage { get; set; }

        /// <summary>The number of votes that make up the rating.</summary>
        [JsonProperty("votes")]
        public int Votes { get; set; }

        /// <summary>Number of users that loved the movie</summary>
        [JsonProperty("loved")]
        public int Loved { get; set; }

        /// <summary>Number of users that hated the movie</summary>
        [JsonProperty("hated")]
        public int Hated { get; set; }
    }

}