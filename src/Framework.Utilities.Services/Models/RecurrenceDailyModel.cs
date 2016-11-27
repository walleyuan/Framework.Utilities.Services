// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecurrenceDailyModel.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the RecurrenceDailyModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.Models
{
    using SOPA.Framework.Models;

    /// <summary>
    /// The recurrence model.
    /// </summary>
    public class RecurrenceDailyModel : RecurrenceRange
    {
        /// <summary>
        /// Gets or sets the days when the event happens recurrently.
        /// For Instance, 4 Days means, the event happens every 4 days.
        /// </summary>
        public int Days { get; set; }
    }
}
