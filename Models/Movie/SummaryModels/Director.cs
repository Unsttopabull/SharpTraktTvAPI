using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Movie.SummaryModels {

    /// <summary>Represents a director in a Trakt.TV movie</summary>
    public class Director {

        /// <summary>Full name.</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>Director thumbnails</summary>
        [JsonProperty("images")]
        public HeadshotImage Images { get; set; }
    }

}