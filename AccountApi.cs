using Frost.SharpTraktTvAPI.Models;
using Frost.SharpTraktTvAPI.Models.Account;

namespace Frost.SharpTraktTvAPI {

    /// <summary>Handles the account side of the Trakt.TV API</summary>
    public class AccountApi {
        private readonly string _apiKey;

        /// <summary>Initializes a new instance of the <see cref="AccountApi"/> class.</summary>
        /// <param name="apiKey">The API key to use.</param>
        public AccountApi(string apiKey) {
            _apiKey = apiKey;
        }

        /// <summary>Creates a new user with specified <paramref name="username"/>, <paramref name="password"/> and <paramref name="email"/>.</summary>
        /// <param name="username">The user username.</param>
        /// <param name="password">The user password.</param>
        /// <param name="email">The user email.</param>
        /// <returns>Returns the status response if the operation succeded or not.</returns>
        public StatusResponse Create(string username, string password, string email) {
            URLBuilder url = new URLBuilder(SharpTraktTv.API_URL_BASE);
            url.AddSegmentPath("account", "create", _apiKey);

            return url.GetPostResponseAs<StatusResponse, AccountCreateInfo>(new AccountCreateInfo(username, password, email));
        }

        /// <summary>Returns the settings of the user with specified info.</summary>
        /// <param name="username">The user username.</param>
        /// <param name="password">The user password.</param>
        /// <returns>Returns the settings information about the user with specified info.</returns>
        public SettingsResponse Settings(string username, string password) {
            URLBuilder url = new URLBuilder(SharpTraktTv.API_URL_BASE);
            url.AddSegmentPath("account", "settings", _apiKey);

            return url.GetPostResponseAs<SettingsResponse, AccountSettingsInfo>(new AccountSettingsInfo(username, password));
        }

        /// <summary>Tests if the user with specified username and password exists.</summary>
        /// <param name="username">The user username.</param>
        /// <param name="password">The user password.</param>
        /// <returns>Returns the status response if the operation succeded or not.</returns>
        public StatusResponse Test(string username, string password) {
            URLBuilder url = new URLBuilder(SharpTraktTv.API_URL_BASE);
            url.AddSegmentPath("account", "test", _apiKey);

            return url.GetPostResponseAs<StatusResponse, AccountSettingsInfo>(new AccountSettingsInfo(username, password));            
        }
    }

}