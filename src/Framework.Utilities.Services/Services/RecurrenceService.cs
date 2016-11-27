// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecurrenceService.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the RecurrenceService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Framework.Utilities.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Framework.Utilities.Services.Enums;
    using Framework.Utilities.Services.Interfaces;
    using Framework.Utilities.Services.Models;

    /// <summary>
    /// The recurrence service.
    /// </summary>
    public class RecurrenceService : IRecurrenceService
    {
        /// <summary>
        /// The check availability for daily events.
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
        public bool CheckAvailability(DateTime currenDate, RecurrenceDailyModel recurringItem)
        {
            int result1 = DateTime.Compare(currenDate, recurringItem.StartDate);
            int result2 = DateTime.Compare(currenDate, recurringItem.EndDate);

            if (result1 >= 0 && result2 <= 0)
            {
                // frequency can't be empty/0
                if (recurringItem.Days == 0)
                {
                    return false;
                }

                if (recurringItem.Days == 1)
                {
                    return true;
                }
                
                if ((currenDate - recurringItem.StartDate).Days % recurringItem.Days != 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The check availability for weekly events.
        /// </summary>
        /// <param name="currentDate">
        /// The date.
        /// </param>
        /// <param name="recurringItem">
        /// The recurring item.
        /// </param>
        /// <returns>
        /// Check whether or not the event is available on the given date.
        /// </returns>
        public bool CheckAvailability(DateTime currentDate, RecurrenceWeeklyModel recurringItem)
        {
            int result1 = DateTime.Compare(currentDate, recurringItem.StartDate);
            int result2 = DateTime.Compare(currentDate, recurringItem.EndDate);

            // check whether or not current date is in recurring period.
            if (result1 >= 0 && result2 <= 0)
            {
                // frequency can't be empty/0
                if (recurringItem.NumOfWeeks == 0)
                {
                    return false;
                }

                var adjustedStarDates = this.AdjustRecurringDate(recurringItem);

                DateTime adjustedStarDate = DateTime.MinValue;
                var initialWeek = 1;


                foreach (var starDate in adjustedStarDates.Where(starDate => starDate.Key.DayOfWeek == currentDate.DayOfWeek))
                {
                    adjustedStarDate = starDate.Key;
                    initialWeek = starDate.Value;
                    break;
                }
                
                if (adjustedStarDate == DateTime.MinValue)
                {
                    return false;
                }
                
                var daysDiff = (currentDate - adjustedStarDate).Days;

                if (initialWeek == 2)
                {
                    daysDiff = daysDiff + 7;
                }

                var weekNumber = daysDiff / 7;

                bool isRecurrentDay = daysDiff % (7 * recurringItem.NumOfWeeks) == 0 && weekNumber % recurringItem.NumOfWeeks == 0;

                switch (currentDate.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        return recurringItem.Monday && isRecurrentDay;
                    case DayOfWeek.Tuesday:
                        return recurringItem.Tuesday && isRecurrentDay;
                    case DayOfWeek.Wednesday:
                        return recurringItem.Wednesday && isRecurrentDay;
                    case DayOfWeek.Thursday:
                        return recurringItem.Thursday && isRecurrentDay;
                    case DayOfWeek.Friday:
                        return recurringItem.Friday && isRecurrentDay;
                    case DayOfWeek.Saturday:
                        return recurringItem.Saturday && isRecurrentDay;
                    case DayOfWeek.Sunday:
                        return recurringItem.Sunday && isRecurrentDay;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The check availability for monthly events.
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
        public bool CheckAvailability(DateTime currenDate, RecurrenceMonthlyModel recurringItem)
        {
            int result1 = DateTime.Compare(currenDate, recurringItem.StartDate);
            int result2 = DateTime.Compare(currenDate, recurringItem.EndDate);

            if (result1 >= 0 && result2 <= 0)
            {
                // frequency can't be empty/0
                if (recurringItem.NumOfMonths == 0)
                {
                    return false;
                }

                if (recurringItem.DateOfMoth > 0)
                {
                    // specified recurring day of the month. i.e. 18th of the month.
                    return currenDate.Day == recurringItem.DateOfMoth
                           && Math.Abs(currenDate.Month - recurringItem.StartDate.Month) % recurringItem.NumOfMonths
                           == 0;
                }
                else
                {
                    // spcified the nth week and weekday that the event will happen. i.e. every first monday every month.
                    return this.CheckNthWeekdayByMonth(recurringItem.Weekday, recurringItem.NthWeekday, currenDate)
                              && Math.Abs(currenDate.Month - recurringItem.StartDate.Month) % recurringItem.NumOfMonths
                              == 0;
                }
            }

            return false;
        }

        /// <summary>
        /// The check availability for yearly events.
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
        public bool CheckAvailability(DateTime currenDate, RecurrenceYearlyModel recurringItem)
        {
            var newStartDate = recurringItem.StartDate;

            int result1 = DateTime.Compare(currenDate, recurringItem.StartDate);
            int result2 = DateTime.Compare(currenDate, recurringItem.EndDate);

            if (result1 >= 0 && result2 <= 0)
            {
                // frequency can't be empty/0
                if (recurringItem.NumOfYears == 0)
                {
                    return false;
                }

                if (recurringItem.DateOfYear != DateTime.MinValue)
                {
                    // spcified date recurring yearly.
                    return currenDate.Month == recurringItem.DateOfYear.Month
                            && currenDate.Day == recurringItem.DateOfYear.Day
                            && (currenDate.Year - recurringItem.StartDate.Year) % recurringItem.NumOfYears == 0;
                }
                else
                {
                    // spcified the nth week and weekday of the month recurring yearly.
                    return this.CheckNthWeekdayByMonth(recurringItem.Weekday, recurringItem.NthWeekday, currenDate)
                           && currenDate.Month == (int)recurringItem.Month
                           && (currenDate.Year - recurringItem.StartDate.Year) % recurringItem.NumOfYears == 0;
                }
            }

            return false;
        }


        /// <summary>
        /// IF THE USER SELECTED WEEK, AT LEAST ONE DAY OF WEEK IS SELECTED.
        /// </summary>
        /// <param name="recurringItem">
        /// The recurring item.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime"/>.
        /// </returns>
        public Dictionary<DateTime, int> AdjustRecurringDate(RecurrenceWeeklyModel recurringItem)
        {
            var availableDates = new Dictionary<DateTime, int>();

            var startDayOfWeek = recurringItem.StartDate.DayOfWeek;
            
            // Monday
            if (recurringItem.Monday)
            {
                availableDates = this.GetAvailableDates(availableDates, recurringItem, startDayOfWeek, DayOfWeek.Monday);
            }

            // Tuesday
            if (recurringItem.Tuesday)
            {
                availableDates = this.GetAvailableDates(availableDates, recurringItem, startDayOfWeek, DayOfWeek.Tuesday);
            }

            // Wednesday
            if (recurringItem.Wednesday)
            {
                availableDates = this.GetAvailableDates(availableDates, recurringItem, startDayOfWeek, DayOfWeek.Wednesday);
            }

            // Thursday
            if (recurringItem.Thursday)
            {
                availableDates = this.GetAvailableDates(availableDates, recurringItem, startDayOfWeek, DayOfWeek.Thursday);
            }

            // Friday
            if (recurringItem.Friday)
            {
                availableDates = this.GetAvailableDates(availableDates, recurringItem, startDayOfWeek, DayOfWeek.Friday);
            }

            // Saturday
            if (recurringItem.Saturday)
            {
                availableDates = this.GetAvailableDates(availableDates, recurringItem, startDayOfWeek, DayOfWeek.Saturday);
            }

            // Sunday
            if (recurringItem.Sunday)
            {
                availableDates = this.GetAvailableDates(availableDates, recurringItem, startDayOfWeek, DayOfWeek.Sunday);
            }

            return availableDates;
        }

        /// <summary>
        /// The get available dates.
        /// </summary>
        /// <param name="availableDates">
        /// The available dates.
        /// </param>
        /// <param name="recurringItem">
        /// The recurring item.
        /// </param>
        /// <param name="startDayOfWeek">
        /// The start day of week.
        /// </param>
        /// <param name="dayOfWeek">
        /// The target day of week.
        /// </param>
        /// <returns>
        /// The list of available dates with week number.
        /// </returns>
        private Dictionary<DateTime, int> GetAvailableDates(
            Dictionary<DateTime, int> availableDates,
            RecurrenceWeeklyModel recurringItem,
            DayOfWeek startDayOfWeek,
            DayOfWeek dayOfWeek)
        {
            if (startDayOfWeek != dayOfWeek)
            {
                var intStartDayOfWeek = startDayOfWeek == DayOfWeek.Sunday ? 7 : (int)startDayOfWeek;
                var intDayOfWeek = dayOfWeek == DayOfWeek.Sunday ? 7 : (int)dayOfWeek;
                
                var date = intDayOfWeek - intStartDayOfWeek > 0
                               ? recurringItem.StartDate.Date.AddDays(intDayOfWeek - intStartDayOfWeek)
                               : recurringItem.StartDate.Date.AddDays(intDayOfWeek - intStartDayOfWeek + 7);

                availableDates.Add(date, intDayOfWeek - intStartDayOfWeek > 0 ? 1 : 2);
            }
            else
            {
                if (!availableDates.ContainsKey(recurringItem.StartDate))
                {
                    availableDates.Add(recurringItem.StartDate, 1);
                }
            }

            return availableDates;
        }


        /// <summary>
        /// The check nth weekday by month.
        /// </summary>
        /// <param name="weekday">
        /// The weekday.
        /// </param>
        /// <param name="nthWeekday">
        /// The nth Weekday.
        /// </param>
        /// <param name="currentDate">
        /// The current Date.
        /// </param>
        /// <returns>
        /// Check if the current day of week is correct.
        /// </returns>
        private bool CheckNthWeekdayByMonth(Weekdays weekday, WeekdaySequences nthWeekday, DateTime currentDate)
        {
            var dates =
                this.GetDates(currentDate.Year, currentDate.Month)
                .Where(date => date.DayOfWeek.ToString() == weekday.ToString())
                .ToList();

            switch (nthWeekday)
            {
                case WeekdaySequences.First:
                    return dates[((int)WeekdaySequences.First - 1)] == currentDate;
                case WeekdaySequences.Second:
                    return dates[((int)WeekdaySequences.Second - 1)] == currentDate;
                case WeekdaySequences.Third:
                    return dates[((int)WeekdaySequences.Third - 1)] == currentDate;
                case WeekdaySequences.Fourth:
                    return dates[((int)WeekdaySequences.Fourth - 1)] == currentDate;
                case WeekdaySequences.Last:
                    return dates[dates.Count() - 1] == currentDate;
            }

            return false;
        }

        /// <summary>
        /// The get dates.
        /// </summary>
        /// <param name="year">
        /// The year.
        /// </param>
        /// <param name="month">
        /// The month.
        /// </param>
        /// <returns>
        /// The all dates of the month.
        /// </returns>
        private List<DateTime> GetDates(int year, int month)
        {
            var dates = new List<DateTime>();

            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            return dates;
        }
    }
}
