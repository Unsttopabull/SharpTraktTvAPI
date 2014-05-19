using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Movie.SummaryModels {

    /// <summary>Represents the person thumbnail</summary>
    [JsonObject(Title = "images")]
    public class HeadshotImage {

        /// <summary>A person thumbnail</summary>
        [JsonProperty("headshot")]
        public string Headshot { get; set; }
    }

}