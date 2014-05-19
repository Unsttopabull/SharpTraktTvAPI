using Frost.SharpTraktTvAPI.Models.Genreal;
using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Search {

    /// <summary>Represents an information about a matched movie</summary>
    public class MovieMatch {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("released")]
        public int Released { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("trailer")]
        public string Trailer { get; set; }

        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("certification")]
        public string Certification { get; set; }

        [JsonProperty("tiimdb_idtle")]
        public string ImdbId { get; set; }

        [JsonProperty("tmdb_id")]
        public int TmdbID { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("genres")]
        public string[] Genres { get; set; }

        [JsonProperty("ratings")]
        public Ratings Ratings { get; set; }
    }

}