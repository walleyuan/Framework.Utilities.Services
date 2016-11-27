// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecurrenceMonthlyModel.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the RecurrenceMonthlyModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Framework.Utilities.Services.Models
{
    using Framework.Utilities.Services.Enums;

    /// <summary>
    /// The recurrence monthly model.
    /// </summary>
    public class RecurrenceMonthlyModel : RecurrenceRange
    {
        /// <summary>
        /// Gets or sets the recurring months.
        /// i.e. recurring every 2 months.
        /// </summary>
        public int NumOfMonths { get; set; }

        /// <summary>
        /// Gets or sets the x day of month.
        /// i.e. 18 it means events recur on 18 every x months.
        /// If DateOfMoth is 0, NthWeekday and Weekday will be used.
        /// </summary>
        public int DateOfMoth { get; set; }

        /// <summary>
        /// Gets or sets nth weekday.
        /// i.e. first, second.
        /// </summary>
        public WeekdaySequences NthWeekday { get; set; }

        /// <summary>
        /// Gets or sets the weekdays.
        /// i.e. Monday, Tuesday.
        /// </summary>
        public Weekdays Weekday { get; set; }
    }
}
