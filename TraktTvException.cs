using System;

namespace Frost.SharpTraktTvAPI {

    /// <summary>An exception that has occured while contacting the Trakt.TV API service.</summary>
    public class TraktTvException : Exception {

        /// <summary>Initializes a new instance of the <see cref="TraktTvException"/> class.</summary>
        /// <param name="error">The error message.</param>
        public TraktTvException(string error) : base(error){
        }

        /// <summary>Initializes a new instance of the <see cref="TraktTvException" /> class.</summary>
        /// <param name="error">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public TraktTvException(string error, Exception innerException) : base(error, innerException){
        }
    }
}
