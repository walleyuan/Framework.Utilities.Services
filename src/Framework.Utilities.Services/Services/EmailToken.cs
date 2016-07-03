// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailToken.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the EmailToken type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The email token.
    /// </summary>
    public class EmailToken
    {
        /// <summary>
        /// Gets or sets the key. The token in HTML template.
        /// </summary> 
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets token value.
        /// </summary>
        public string Value { get; set; }
    }
}