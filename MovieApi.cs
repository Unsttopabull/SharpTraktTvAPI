using System.Collections.Generic;
using System.Linq;
using Frost.SharpTraktTvAPI.Models.Movie;
using Frost.SharpTraktTvAPI.Models.Movie.SummariesModels;

namespace Frost.SharpTraktTvAPI {

    /// <summary>The movie plot length</summary>
    public enum SummaryLength {
        /// <summary>The default length.</summary>
        Default,
        /// <summary>The normal length.</summary>
        Normal,
        /// <summary>Extended length.</summary>
        Full
    }

    /// <summary>Handles the movie information side of the Trakt.TV API</summary>
    public class MovieApi {
        private readonly string _apiKey;

        /// <summary>Initializes a new instance of the <see cref="MovieApi"/> class.</summary>
        /// <param name="apiKey">The API key to use.</param>
        public MovieApi(string apiKey) {
            _apiKey = apiKey;
        }

        #region Summary

        /// <summary>Gets the movie summary using the movie slug provided</summary>
        /// <param name="titleSlug">The movie slug.</param>
        /// <returns>Returns the summary of the movie searched or throw an exception.</returns>
        /// <exception cref="TraktTvException">Throws if there was an error downloading the data or an error decompressing or deserializing the response JSON.</exception>
        public MovieSummaryResponse Summary(string titleSlug) {
            return GetSummary(titleSlug);
        }

        /// <summary>Creates the movie slug using the title and release year and used that to search for a movie summary.</summary>
        /// <param name="title">The movie title.</param>
        /// <param name="year">The movie release year.</param>
        /// <returns>Returns the summary of the movie searched or throw an exception.</returns>
        /// <exception cref="TraktTvException">Throws if there was an error downloading the data or an error decompressing or deserializing the response JSON.</exception>
        public MovieSummaryResponse SummaryByTitleAndYear(string title, int year) {
            return GetSummary(title.Replace(" ", "-") + "-" + year);
        }

        /// <summary>Gets the movie summary using the movie either IMDB Id or TMDB Id.</summary>
        /// <param name="id">The IMDB or TMDB Id.</param>
        /// <returns>Returns the summary of the movie searched or throw an exception.</returns>
        /// <exception cref="TraktTvException">Throws if there was an error downloading the data or an error decompressing or deserializing the response JSON.</exception>
        public MovieSummaryResponse SummaryById(string id) {
            return GetSummary(id);
        }

        private MovieSummaryResponse GetSummary(string value) {
            URLBuilder url = new URLBuilder(SharpTraktTv.API_URL_BASE);
            url.AddSegmentPath("movie", "summary.json", _apiKey, value);

            return url.GetResposeAs<MovieSummaryResponse>();
        }

        #endregion

        #region Summaries

        /// <summary>Returns the information about one or more movies.</summary>
        /// <param name="extended">The plot length prefered.</param>
        /// <param name="values">The search values.</param>
        /// <returns>Returns the a brief summaries of the movies searched or throws an exception.</returns>
        public MovieSummaries Summaries(SummaryLength extended, params MovieSummarySearch[] values) {
            return GetSummaries(values.Select(ms => ms.GetSlug()), extended);
        }

        /// <summary>Returns the information about one or more movies.</summary>
        /// <param name="values">The search values.</param>
        /// <returns>Returns the a brief summaries of the movies searched or throws an exception.</returns>
        public MovieSummaries Summaries(params MovieSummarySearch[] values) {
            return GetSummaries(values.Select(ms => ms.GetSlug()));
        }

        /// <summary>Returns the information about one or more movies by their Imdb or Tmbd Ids.</summary>
        /// <param name="id">The Imdb or Tmbd Ids.</param>
        /// <returns>Returns the a brief summaries of the movies searched or throws an exception.</returns>
        public MovieSummaries SummariesById(params string[] id) {
            return GetSummaries(id);
        }

        private MovieSummaries GetSummaries(IEnumerable<string> values, SummaryLength length = SummaryLength.Default) {
            URLBuilder url = new URLBuilder(SharpTraktTv.API_URL_BASE);
            url.AddSegmentPath("movie", "summaries.json", _apiKey, string.Join(",", values));

            if (length != SummaryLength.Default) {
                url.AddSegment(length.ToString().ToLowerInvariant());
            }

            return url.GetResposeAs<MovieSummaries>();
        }

        #endregion

    }
}
