using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Frost.SharpTraktTvAPI {

    /// <summary>Represents the REST URI builder and handler</summary>
    public class URLBuilder {
        private readonly StringBuilder _uri;
        private bool _first = true;

        /// <summary>Initializes a new instance of the <see cref="URLBuilder"/> class.</summary>
        /// <param name="baseUri">The base URI value.</param>
        public URLBuilder(string baseUri) {
            _uri = new StringBuilder(baseUri);
        }

        /// <summary>Adds the URL parameter to the end of the URI and optionaly URL Encodes the value.</summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="paramName">The name of the parameter to use.</param>
        /// <param name="value">The value to use (ToString() will be called).</param>
        /// <param name="urlEncode">If set to <c>true</c> the string value of the <paramref name="value"/> will be URL Encoded.</param>
        public void AddParameter<T>(string paramName, T value, bool urlEncode = false) {
            if (_first) {
                _uri.Append("?");
                _first = false;
            }
            else {
                _uri.Append("&");
            }

            _uri.Append(paramName);
            _uri.Append("=");

            if (urlEncode) {
                _uri.Append(WebUtility.UrlEncode(value.ToString().TrimEnd('-')));
            }
            else {
                _uri.Append(value);
            }
        }

        /// <summary>Adds the URL segment "/something/" to the end of the URI.</summary>
        /// <param name="segmentName">The segment name to use.</param>
        /// <param name="trailingSlash">if set to <c>true</c> "/" will be added to the end of the string.</param>
        public void AddSegment(string segmentName, bool trailingSlash = true) {
            _uri.Append(segmentName);
            if (trailingSlash) {
                _uri.Append("/");
            }
        }

        /// <summary>Adds the URL segments "/something/" to the end of the URI in the order they were passed in.</summary>
        /// <param name="segments">An array of segments in order to add to the URL.</param>
        public void AddSegmentPath(params string[] segments) {
            _uri.Append(string.Join("/", segments) + "/");
        }

        /// <summary>Converts the current URL value to string</summary>
        public string ToUri() {
            return _uri.ToString();
        }

        /// <summary>Downloads the content at the current url by HTTP GET and deserializes the expected json as the specified type.</summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <returns>Returns the deserialized JSON into an instance of <typeparamref name="T"/> or the default value of <typeparamref name="T"/>.</returns>
        /// <exception cref="TraktTvException">Throws if there was an error downloading the data or an error decompressing or deserializing JSON.</exception>
        public T GetResposeAs<T>() {
            string response = GetRequest();
            if (string.IsNullOrEmpty(response)) {
                return default(T);
            }

            return ThrowOnFailure(response).ToObject<T>();
        }

        /// <summary>Downloads the content at the current url by HTTP POST and deserializes the expected json as the specified type.</summary>
        /// <param name="data">The data to POST.</param>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <returns>Returns the deserialized JSON into an instance of <typeparamref name="T"/> or the default value of <typeparamref name="T"/>.</returns>
        /// <exception cref="TraktTvException">Throws if there was an error downloading/posting the data or an error decompressing or deserializing JSON.</exception>
        public T GetPostResponseAs<T>(string data) {
            string response = PostRequest(data);
            if (string.IsNullOrEmpty(response)) {
                return default(T);
            }

            return ThrowOnFailure(response).ToObject<T>();
        }

        /// <summary>Downloads the content at the current url by HTTP POST by serializing the data to JSON and deserializes the response JSON to the specified type.</summary>
        /// <typeparam name="TData">The type of the data to serialize.</typeparam>
        /// <typeparam name="TResponse">The type of the response to deserialize.</typeparam>
        /// <returns>Returns the deserialized JSON into an instance of <typeparamref name="TResponse"/> or the default value of <typeparamref name="TResponse"/>.</returns>
        /// <exception cref="TraktTvException">Throws if there was an error downloading/posting the data or an error decompressing or deserializing JSON.</exception>
        public TResponse GetPostResponseAs<TResponse, TData>(TData data) {
            string response = PostRequest(data);
            if (string.IsNullOrEmpty(response)) {
                return default(TResponse);
            }

            return ThrowOnFailure(response).ToObject<TResponse>();
        }

        /// <summary>Downloads the content at the current url by HTTP POST by serializing the data to JSON and returning the response as string.</summary>
        /// <typeparam name="T">The type of the data to serialize.</typeparam>
        /// <returns>Returns the response as string.</returns>
        /// <exception cref="TraktTvException">Throws if there was an error downloading/posting or serializing the data or an error decompressing the response.</exception>
        public string PostRequest<T>(T data) {
            return PostRequest(JsonConvert.SerializeObject(data));
        }

        /// <summary>Sends the string data to the current URI using the HTTP POST.</summary>
        /// <param name="data">The data to send.</param>
        /// <returns>Returns the response as string.</returns>
        /// <exception cref="TraktTvException">Throws if there was an error downloading/posting the data or an error decompressing the response.</exception>
        public string PostRequest(string data) {
            using (WebClient wc = new WebClient()) {
                wc.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
                try {
                    string response = wc.UploadString(_uri.ToString(), data);

                    string  contentEncoding = wc.ResponseHeaders["Content-Encoding"];
                    if (contentEncoding != null && contentEncoding == "gzip") {
                        using (StreamReader sr = new StreamReader(new GZipStream(new MemoryStream(Encoding.UTF8.GetBytes(response)), CompressionMode.Decompress))) {
                            response = sr.ReadToEnd();
                        }
                    }
                    return response;
                }
                catch (WebException e) {
                    return HandleWebException(e);
                }
                catch (Exception) {
                    return null;
                }
            }
        }

        /// <summary>Retrieves the response at the current URI using HTTP GET.</summary>
        /// <returns>The reponse as string</returns>
        /// <exception cref="TraktTvException">Throws if there was an error retrieving or decompressing the response.</exception>
        public string GetRequest() {
            using (WebClient wc = new WebClient()) {
                wc.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");

                try {
                    byte[] response = wc.DownloadData(_uri.ToString());
                    string json;

                    string  contentEncoding = wc.ResponseHeaders["Content-Encoding"];
                    if (contentEncoding != null && contentEncoding == "gzip") {
                        using (StreamReader sr = new StreamReader(new GZipStream(new MemoryStream(response), CompressionMode.Decompress))) {
                            json = sr.ReadToEnd();
                        }
                    }
                    else {
                        json = Encoding.UTF8.GetString(response);
                    }
                    return json;
                }
                catch (WebException e) {
                    return HandleWebException(e);
                }
                catch (Exception) {
                    return null;
                }
            }
        }

        private string HandleWebException(WebException e) {
            HttpWebResponse response = e.Response as HttpWebResponse;
            if (response != null && response.StatusCode == HttpStatusCode.NotFound && response.ContentLength > 0) {
                using (Stream stream = response.ContentEncoding == "gzip"
                                           ? new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)
                                           : response.GetResponseStream()) {

                    if (stream != null) {
                        string json;
                        using (StreamReader sr = new StreamReader(stream)) {
                            json = sr.ReadToEnd();
                        }
                        ThrowOnFailure(json);
                    }
                }
            }

            return null;
        }

        private JContainer ThrowOnFailure(string json) {

            if (json.StartsWith("[")) {
                try {
                    return JArray.Parse(json);
                }
                catch (Exception e) {
                    throw new TraktTvException("Failed to parse the response as JSON.", e);
                }
            }

            JObject jObject;
            try {
                jObject = JObject.Parse(json);
            }
            catch (Exception e) {
                throw new TraktTvException("Failed to parse the response as JSON.", e);
            }

            if (jObject.Count == 2) {
                JProperty status = jObject.Property("status");
                if (status != null && status.ToObject<string>() == "failure") {
                    string error = jObject.Property("error").ToObject<string>();
                    throw new TraktTvException(error);
                }
            }
            return jObject;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() {
            return _uri.ToString();
        }
    }

}