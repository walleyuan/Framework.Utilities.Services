// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Underwriting.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the Underwriting type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.UnitTest
{
    using Newtonsoft.Json;

    /// <summary>
    /// The underwriting.
    /// </summary>
    public class Underwriting
    {
        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        [JsonProperty("ApplicationId")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        [JsonProperty("RoleId")]
        public string RoleId { get; set; }

        /// <summary>
        /// Gets or sets the fund.
        /// </summary>
        [JsonProperty("Fund")]
        public string Fund { get; set; }

        /// <summary>
        /// Gets or sets the fund name.
        /// </summary>
        [JsonProperty("FundName")]
        public string FundName { get; set; }
    }
}
