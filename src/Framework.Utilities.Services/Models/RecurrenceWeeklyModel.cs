// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecurrenceWeeklyModel.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the RecurrenceWeeklyModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Framework.Utilities.Services.Models
{
    /// <summary>
    /// The recurrence weekly model.
    /// </summary>
    public class RecurrenceWeeklyModel : RecurrenceRange
    {
        /// <summary>
        /// Gets or sets the recurring weeks.
        /// i.e. recurring every 2 weeks.
        /// </summary>
        public int NumOfWeeks { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether monday.
        /// </summary>
        public bool Monday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether tuesday.
        /// </summary>
        public bool Tuesday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether wednesday.
        /// </summary>
        public bool Wednesday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether thursday.
        /// </summary>
        public bool Thursday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether friday.
        /// </summary>
        public bool Friday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether saturday.
        /// </summary>
        public bool Saturday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether sunday.
        /// </summary>
        public bool Sunday { get; set; }
    }
}
