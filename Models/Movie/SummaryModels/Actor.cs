using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Movie.SummaryModels {

    /// <summary>Represents an actor in a Trakt.TV movie</summary>
    public class Actor {

        /// <summary>The actor full name.</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>The actor character or role.</summary>
        [JsonProperty("character")]
        public string Character { get; set; }

        /// <summary>Actor thumbnails</summary>
        [JsonProperty("images")]
        public HeadshotImage Images { get; set; }
    }

}