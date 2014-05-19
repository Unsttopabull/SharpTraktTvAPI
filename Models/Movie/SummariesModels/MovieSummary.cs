using Frost.SharpTraktTvAPI.Models.Genreal;
using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Movie.SummariesModels {

    /// <summary>The summary of a matched movie.</summary>
    public class MovieSummary {

        /// <summary>The movie title.</summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>The movie release year.</summary>
        [JsonProperty("year")]
        public int RleaseYear { get; set; }

        /// <summary>The Imdb Id of this movie.</summary>
        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        /// <summary>The Tmdb Id of this movie.</summary>
        [JsonProperty("tmdb_id")]
        public string TmdbId { get; set; }

        /// <summary>The time this info was last updated.</summary>
        [JsonProperty("last_updated")]
        public int LastUpdated { get; set; }

        /// <summary>The released date of this movie.</summary>
        [JsonProperty("released")]
        public int Released { get; set; }

        /// <summary>The trailer url.</summary>
        [JsonProperty("trailer")]
        public string Trailer { get; set; }

        /// <summary>Movie duration.</summary>
        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        /// <summary>Movie tagline.</summary>
        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        /// <summary>Movie plot overview.</summary>
        [JsonProperty("overview")]
        public string Overview { get; set; }

        /// <summary>Movie certification.</summary>
        [JsonProperty("certification")]
        public string Certification { get; set; }

        /// <summary>Movie website.</summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>Movie cover/poster.</summary>
        [JsonProperty("images")]
        public Images Images { get; set; }

        /// <summary>Movie genres.</summary>
        [JsonProperty("genres")]
        public string[] Genres { get; set; }
    }

}