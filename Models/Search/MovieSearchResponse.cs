namespace Frost.SharpTraktTvAPI.Models.Search {

    /// <summary>Represents the movie search matches.</summary>
    public class MovieSearchResponse {
        /// <summary>General info about a matched movie (in order)</summary>
        public MovieMatch[] Matches { get; set; }
    }

}
