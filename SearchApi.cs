using Frost.SharpTraktTvAPI.Models.Search;

namespace Frost.SharpTraktTvAPI {

    /// <summary>Handles the searching of the Trakt.TV API data</summary>
    public class SearchApi {
        private readonly string _apiKey;

        /// <summary>Initializes a new instance of the <see cref="SearchApi"/> class.</summary>
        /// <param name="apiKey">The API key to use.</param>
        public SearchApi(string apiKey) {
            _apiKey = apiKey;
        }

        /// <summary>Searches for movies using the query.</summary>
        /// <param name="query">The query to use.</param>
        /// <param name="limit">Maximum number of results to return.</param>
        /// <returns>Returns an array of matches</returns>
        public MovieMatch[] SearchMovies(string query, int limit = 30) {
            URLBuilder url = new URLBuilder(SharpTraktTv.API_URL_BASE);
            url.AddSegmentPath("search", "movies.json");
            url.AddSegment(_apiKey, false);
            url.AddParameter("query", query, true);

            if (limit != 30) {
                url.AddParameter("limit", limit);
            }

            return url.GetResposeAs<MovieMatch[]>();
        }
    }
}
