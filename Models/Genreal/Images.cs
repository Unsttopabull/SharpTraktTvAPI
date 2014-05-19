using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Genreal {

    /// <summary>Represents the Trakt.TV movie promotional images (posters/fanart/covers)</summary>
    public class Images {

        /// <summary>Movie poster</summary>
        [JsonProperty("poster")]
        public string Poster { get; set; }

        /// <summary>Movie poster small (138)</summary>
        [JsonIgnore]
        public string PosterSmall {
            get { return GetSpecificSize(Poster, 138); }
        }

        /// <summary>Movie poster medium (300)</summary>
        [JsonIgnore]
        public string PosterMedium {
            get { return GetSpecificSize(Poster, 300); }
        }

        /// <summary>Movie fanart</summary>
        [JsonProperty("fanart")]
        public string Fanart { get; set; }

        /// <summary>Movie fanart small (218)</summary>
        [JsonIgnore]
        public string FanartSmall {
            get { return GetSpecificSize(Fanart, 218); }
        }

        /// <summary>Movie fanart medium (940)</summary>
        [JsonIgnore]
        public string FanartMedium {
            get { return GetSpecificSize(Fanart, 940); }
        }

        private string GetSpecificSize(string path, int size) {
            if (string.IsNullOrEmpty(path)) {
                return null;
            }

            int idxForward = path.LastIndexOf('/');
            string path2;
            if (idxForward > 0) {
                path2 = path.Substring(0, idxForward + 1);
            }
            else {
                return null;
            }


            string withoutExt = System.IO.Path.GetFileNameWithoutExtension(path);
            string ext = System.IO.Path.GetExtension(path);

            return string.Format("{0}{1}-{2}{3}", path2, withoutExt, size, ext);
        }
    }

}