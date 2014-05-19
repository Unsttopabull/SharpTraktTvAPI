using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Movie.SummaryModels {

    public class Top_Watchers {
        public int plays { get; set; }
        public string username { get; set; }

        [JsonProperty("protected")]
        public bool IsProtected { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public string location { get; set; }
        public string about { get; set; }
        public int joined { get; set; }
        public string avatar { get; set; }
        public string url { get; set; }
    }

}