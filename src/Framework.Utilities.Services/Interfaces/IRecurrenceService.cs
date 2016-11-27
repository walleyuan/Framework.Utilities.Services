// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRecurrenceService.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the IRecurrenceService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Framework.Utilities.Services.Interfaces
{
    using System;
    using Framework.Utilities.Services.Models;

    /// <summary>
    /// The IRecurrence service.
    /// </summary>
    public interface IRecurrenceService
    {
        /// <summary>
        /// The check availability.
        /// </summary>
        /// <param name="currenDate">
        /// The date.
        /// </param>
        /// <param name="recurringItem">
        /// The recurring item.
        /// </param>
        /// <returns>
        /// Check whether or not the event is available on the given date.
        /// </returns>
        bool CheckAvailability(DateTime currenDate,  RecurrenceDailyModel recurringItem);

        /// <summary>
        /// The check availability.
        /// </summary>
        /// <param name="currenDate">
        /// The date.
        /// </param>
        /// <param name="recurringItem">
        /// The recurring item.
        /// </param>
        /// <returns>
        /// Check whether or not the event is available on the given date.
        /// </returns>
        bool CheckAvailability(DateTime currenDate, RecurrenceWeeklyModel recurringItem);

        /// <summary>
        /// The check availability.
        /// </summary>
        /// <param name="currenDate">
        /// The date.
        /// </param>
        /// <param name="recurringItem">
        /// The recurring item.
        /// </param>
        /// <returns>
        /// Check whether or not the event is available on the given date.
        /// </returns>
        bool CheckAvailability(DateTime currenDate, RecurrenceMonthlyModel recurringItem);

        /// <summary>
        /// The check availability.
        /// </summary>
        /// <param name="currenDate">
        /// The date.
        /// </param>
        /// <param name="recurringItem">
        /// The recurring item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool CheckAvailability(DateTime currenDate, RecurrenceYearlyModel recurringItem);
    }
}
