// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecurrenceRange.cs" company="Gruden">
//   Copyright (c) Gruden. All rights reserved.
// </copyright>
// <summary>
//   Defines the RecurrenceRange type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.Models
{
    using System;

    /// <summary>
    /// The recurrence range.
    /// </summary>
    public class RecurrenceRange
    {
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
