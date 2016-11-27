// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecurrenceYearlyModel.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the RecurrenceYearlyModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.Models
{
    using System;

    using global::Framework.Utilities.Services.Enums;

    using SOPA.Framework.Models;

    /// <summary>
    /// The recurrence yearly model.
    /// </summary>
    public class RecurrenceYearlyModel : RecurrenceRange
    {
        /// <summary>
        /// Gets or sets the recurring months.
        /// i.e. recurring every 2 year.
        /// </summary>
        public int NumOfYears { get; set; }

        /// <summary>
        /// Gets or sets the day of year.
        /// i.e. The event happens on 18 of Jan yearly.
        /// </summary>
        public DateTime DateOfYear { get; set; }

        /// <summary>
        /// Gets or sets nth weekday.
        /// i.e. first, second.
        /// </summary>
        public WeekdaySequences NthWeekday { get; set; }

        /// <summary>
        /// Gets or sets the weekdays.
        /// i.e. monday.
        /// </summary>
        public Weekdays Weekday { get; set; }

        /// <summary>
        /// Gets or sets the month.
        /// i.e. Jan, Feb.
        /// </summary>
        public Months Month { get; set; }
    }
}
