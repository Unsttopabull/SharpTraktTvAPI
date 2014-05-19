using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Movie.SummaryModels {

    /// <summary>Represents a writer in a Trakt.TV movie</summary>
    public class Writer {

        /// <summary>Full name.</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>The writer job (screenplay, script etc.).</summary>
        [JsonProperty("job")]
        public string Job { get; set; }

        /// <summary>Writer thumbnails</summary>
        [JsonProperty("images")]
        public HeadshotImage Images { get; set; }
    }

}