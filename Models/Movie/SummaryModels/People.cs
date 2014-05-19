using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Movie.SummaryModels {

    /// <summary>Represents the cast of a Trakt.TV movie.</summary>
    public class People {

        /// <summary>Movie directors</summary>
        [JsonProperty("directors")]
        public Director[] Directors { get; set; }

        /// <summary>Movie writers</summary>
        [JsonProperty("writers")]
        public Writer[] Writers { get; set; }

        /// <summary>Movie producers</summary>
        [JsonProperty("producers")]
        public Producer[] Producers { get; set; }

        /// <summary>Movie actors</summary>
        [JsonProperty("actors")]
        public Actor[] Actors { get; set; }
    }

}