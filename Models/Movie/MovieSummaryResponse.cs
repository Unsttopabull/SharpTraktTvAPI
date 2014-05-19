using Frost.SharpTraktTvAPI.Models.Genreal;
using Frost.SharpTraktTvAPI.Models.Movie.SummaryModels;
using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Movie {

    public class MovieSummaryResponse {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("year")]
        public int ReleaseYear { get; set; }

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

        [JsonProperty("imdb_id")]
        public string ImdbID { get; set; }

        [JsonProperty("tmdb_id")]
        public int TmdbID { get; set; }

        [JsonProperty("rt_id")]
        public int RtID { get; set; }

        [JsonProperty("last_updated")]
        public int LastUpdated { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("genres")]
        public string[] Genres { get; set; }

        [JsonProperty("top_watchers")]
        public Top_Watchers[] TopWatchers { get; set; }

        [JsonProperty("ratings")]
        public Ratings Ratings { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("people")]
        public People People { get; set; }

        [JsonProperty("watched")]
        public bool Watched { get; set; }

        [JsonProperty("plays")]
        public int Plays { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("rating_advanced")]
        public int RatingAdvanced { get; set; }

        [JsonProperty("in_watchlist")]
        public bool InWatchlist { get; set; }

        [JsonProperty("in_collection")]
        public bool InCollection { get; set; }
    }

}
