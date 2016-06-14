// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationToken.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the AuthenticationToken type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.UnitTest
{
    using Newtonsoft.Json;

    /// <summary>
    /// The authentication token.
    /// </summary>
    public class AuthenticationToken
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the token type.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the issued.
        /// </summary>
        [JsonProperty(".issued")]
        public string Issued { get; set; }

        /// <summary>
        /// Gets or sets the expires.
        /// </summary>
        [JsonProperty(".expires")]
        public string Expires { get; set; }
    }
}
