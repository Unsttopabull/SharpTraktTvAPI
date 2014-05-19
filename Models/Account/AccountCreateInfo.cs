using Newtonsoft.Json;

namespace Frost.SharpTraktTvAPI.Models.Account {

    /// <summary>Represents the info required to create a new user.</summary>
    internal class AccountCreateInfo : AccountSettingsInfo {

        /// <summary>Initializes a new instance of the <see cref="AccountCreateInfo"/> class.</summary>
        public AccountCreateInfo(string username, string password, string email) : base(username, password){
            Email = email;
        }

        /// <summary>The user email</summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }

}