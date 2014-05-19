namespace Frost.SharpTraktTvAPI.Models.Movie.SummariesModels {

    /// <summary>Represents the movie info required to search on Trakt.TV</summary>
    public class MovieSummarySearch {

        /// <summary>Initializes a new instance of the <see cref="MovieSummarySearch"/> class.</summary>
        public MovieSummarySearch(string title, int releaseYear) {
            Title = title;
            ReleaseYear = releaseYear;
        }

        /// <summary>The movie title.</summary>
        public string Title { get; set; }

        /// <summary>The release year.</summary>
        public int ReleaseYear { get; set; }

        /// <summary>Creates the movie slug from title and release year.</summary>
        /// <returns>The movie slug.</returns>
        public string GetSlug() {
            return Title.Replace(" ", "-") + "-" + ReleaseYear;
        }
    }
}
