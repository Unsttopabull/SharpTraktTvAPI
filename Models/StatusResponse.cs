namespace Frost.SharpTraktTvAPI.Models {

    /// <summary>Represents the Trakt.TV API status repsose.</summary>
    public class StatusResponse {

        /// <summary>HTTP Status code</summary>
        public string Status { get; set; }

        /// <summary>API Error message</summary>
        public string Error { get; set; }
    }
}
