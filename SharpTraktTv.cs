namespace Frost.SharpTraktTvAPI {

    /// <summary>Trakt.TV API Client</summary>
    public class SharpTraktTv {
        private readonly string _apiKey;
        internal const string API_URL_BASE = "http://api.trakt.tv/";

        /// <summary>Initializes a new instance of the <see cref="SharpTraktTv"/> class.</summary>
        /// <param name="apiKey">The API key to use when contacting the Trakt.TV API.</param>
        public SharpTraktTv(string apiKey) {
            _apiKey = apiKey;

            Account = new AccountApi(apiKey);
            Movie = new MovieApi(apiKey);
            Search = new SearchApi(apiKey);
        }

        /// <summary>Handles the Account side out the API.</summary>
        public AccountApi Account { get; private set; }

        /// <summary>Handles the Movie information side out the API.</summary>
        public MovieApi Movie { get; private set; }

        /// <summary>Handles the Searching of the API data.</summary>
        public SearchApi Search { get; private set; }
    }

}