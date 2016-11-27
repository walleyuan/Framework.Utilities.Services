// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecurrenceServiceUnitTests.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the RecurrenceServiceUnitTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.UnitTest.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Framework.Utilities.Services.Enums;
    using Framework.Utilities.Services.Models;
    using Framework.Utilities.Services.Services;
    using Framework.Utilities.Services.UnitTest.Models;
    using NUnit.Framework;

    /// <summary>
    /// The recurrence service unit tests.
    /// </summary>
    [TestFixture]
    public class RecurrenceServiceUnitTests
    {
        /// <summary>
        /// Gets or sets the daily events.
        /// </summary>
        public IEnumerable<RecurrenceDailyModel> DailyEvents { get; set; }

        /// <summary>
        /// Gets or sets the weekly events.
        /// </summary>
        public IEnumerable<RecurrenceWeeklyModel> WeeklyEvents { get; set; }

        /// <summary>
        /// Gets or sets the monthly events.
        /// </summary>
        public IEnumerable<RecurrenceMonthlyModel> MonthlyEvents { get; set; }

        /// <summary>
        /// Gets or sets the yearly events.
        /// </summary>
        public IEnumerable<RecurrenceYearlyModel> YearlyEvents { get; set; }

        /// <summary>
        /// The run before any tests.
        /// </summary>
        [SetUp]
        public void Init()
        {
            // Mock up Daily Events
            this.DailyEvents = RecurrenceModels.GetDailyModels();
            
            // Mock up Weekly Events
            this.WeeklyEvents = RecurrenceModels.GetWeeklyModels();

            // Mock up Monthly Events
            this.MonthlyEvents = RecurrenceModels.GetMonthlyModels();

            // Mock up Yearly Events
            this.YearlyEvents = RecurrenceModels.GetYearlyModels();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            this.DailyEvents = null;
            this.WeeklyEvents = null;
            this.MonthlyEvents = null;
        }

        /// <summary>
        /// The test check availability.
        /// </summary>
        /// <param name="currentDate">
        /// The current Date.
        /// </param>
        /// <param name="frequency">
        /// The frequency.
        /// </param>
        /// <returns>
        /// Real Total correct numbers
        /// </returns>
        [TestCase("1/11/2016", 3, ExpectedResult = true)]
        [TestCase("2/11/2016", 3, ExpectedResult = false)]
        [TestCase("3/11/2016", 3, ExpectedResult = false)]
        [TestCase("4/11/2016", 3, ExpectedResult = true)]
        [TestCase("5/11/2016", 3, ExpectedResult = false)]
        [TestCase("6/11/2016", 3, ExpectedResult = false)]
        [TestCase("7/11/2016", 3, ExpectedResult = true)]
        [TestCase("8/11/2016", 3, ExpectedResult = false)]
        [TestCase("9/11/2016", 3, ExpectedResult = false)]
        [TestCase("10/11/2016", 3, ExpectedResult = true)]
        [TestCase("11/11/2016", 3, ExpectedResult = false)]
        [TestCase("12/11/2016", 3, ExpectedResult = false)]
        [TestCase("13/11/2016", 3, ExpectedResult = true)]
        [TestCase("14/11/2016", 3, ExpectedResult = false)]
        [TestCase("15/11/2016", 3, ExpectedResult = false)]
        [TestCase("16/11/2016", 3, ExpectedResult = true)]
        [TestCase("17/11/2016", 3, ExpectedResult = false)]
        [TestCase("18/11/2016", 3, ExpectedResult = false)]
        [TestCase("19/11/2016", 3, ExpectedResult = true)]
        [TestCase("20/11/2016", 3, ExpectedResult = false)]
        [TestCase("21/11/2016", 3, ExpectedResult = false)]
        [TestCase("22/11/2016", 3, ExpectedResult = true)]
        [TestCase("23/11/2016", 3, ExpectedResult = false)]
        [TestCase("24/11/2016", 3, ExpectedResult = false)]
        [TestCase("25/11/2016", 3, ExpectedResult = true)]
        [TestCase("26/11/2016", 3, ExpectedResult = false)]
        [TestCase("27/11/2016", 3, ExpectedResult = false)]
        [TestCase("28/11/2016", 3, ExpectedResult = true)]
        [TestCase("29/11/2016", 3, ExpectedResult = false)]
        [TestCase("30/11/2016", 3, ExpectedResult = false)]
        [TestCase("01/12/2016", 3, ExpectedResult = true)]
        [TestCase("02/12/2016", 3, ExpectedResult = false)]
        public bool TestCheckAvailabilityForDailyEvents(string currentDate, int frequency)
        {
            var service = new RecurrenceService();

            // recur every day.
            var model = new RecurrenceDailyModel
                            {
                                StartDate = DateTime.Parse("01/11/2016"),
                                EndDate = DateTime.Parse("31/01/2017"),
                                Days = frequency
                            };

            return service.CheckAvailability(DateTime.Parse(currentDate), model);
        }



        /// <summary>
        /// The test get closest recurring date.
        /// </summary>
        /// <param name="startDate">
        /// The start Date.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [TestCase("01/11/2016", ExpectedResult = "3/11/2016")]
        [TestCase("02/11/2016", ExpectedResult = "3/11/2016")]
        [TestCase("03/11/2016", ExpectedResult = "3/11/2016")]
        [TestCase("04/11/2016", ExpectedResult = "4/11/2016")]
        [TestCase("05/11/2016", ExpectedResult = "6/11/2016")]
        [TestCase("06/11/2016", ExpectedResult = "6/11/2016")]
        [TestCase("07/11/2016", ExpectedResult = "7/11/2016")]
        [TestCase("08/11/2016", ExpectedResult = "10/11/2016")]
        [TestCase("09/11/2016", ExpectedResult = "10/11/2016")]
        [TestCase("10/11/2016", ExpectedResult = "10/11/2016")]
        [TestCase("11/11/2016", ExpectedResult = "11/11/2016")]
        [TestCase("12/11/2016", ExpectedResult = "13/11/2016")]
        [TestCase("13/11/2016", ExpectedResult = "13/11/2016")]
        [TestCase("14/11/2016", ExpectedResult = "14/11/2016")]
        [TestCase("15/11/2016", ExpectedResult = "17/11/2016")]
        [TestCase("16/11/2016", ExpectedResult = "17/11/2016")]
        [TestCase("17/11/2016", ExpectedResult = "17/11/2016")]
        [TestCase("18/11/2016", ExpectedResult = "18/11/2016")]
        [TestCase("19/11/2016", ExpectedResult = "20/11/2016")]
        [TestCase("20/11/2016", ExpectedResult = "20/11/2016")]
        [TestCase("21/11/2016", ExpectedResult = "21/11/2016")]
        [TestCase("22/11/2016", ExpectedResult = "24/11/2016")]
        [TestCase("23/11/2016", ExpectedResult = "24/11/2016")]
        [TestCase("24/11/2016", ExpectedResult = "24/11/2016")]
        [TestCase("25/11/2016", ExpectedResult = "25/11/2016")]
        [TestCase("26/11/2016", ExpectedResult = "27/11/2016")]
        [TestCase("27/11/2016", ExpectedResult = "27/11/2016")]
        [TestCase("28/11/2016", ExpectedResult = "28/11/2016")]
        [TestCase("29/11/2016", ExpectedResult = "1/12/2016")]
        [TestCase("30/11/2016", ExpectedResult = "1/12/2016")]

        public string TestAdjustRecurringDate(string startDate)
        {
            var service = new RecurrenceService();

            var model = new RecurrenceWeeklyModel
            {
                StartDate = DateTime.Parse(startDate),
                EndDate = DateTime.Parse("31/1/2017"),
                NumOfWeeks = 1,
                Monday = true,
                Tuesday = false,
                Wednesday = false,
                Thursday = true,
                Friday = true,
                Saturday = false,
                Sunday = true
            };

            var availableDates = service.AdjustRecurringDate(model);

            var result = availableDates.Keys.Min(x => x.Date);

            return result.Date.ToString("d/MM/yyyy");
        }

        /// <summary>
        /// The test check availability for weekly events.
        /// </summary>
        /// <param name="currentDate">
        /// The current date.
        /// </param>
        /// <param name="frequency">
        /// The frequency.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        [TestCase("1/11/2016", 1,  ExpectedResult = false)]
        [TestCase("2/11/2016", 1, ExpectedResult = false)]
        [TestCase("3/11/2016", 1, ExpectedResult = true)]
        [TestCase("4/11/2016", 1, ExpectedResult = true)]
        [TestCase("5/11/2016", 1, ExpectedResult = false)]
        [TestCase("6/11/2016", 1, ExpectedResult = true)]
        [TestCase("7/11/2016", 1, ExpectedResult = true)]
        [TestCase("8/11/2016", 1, ExpectedResult = false)]
        [TestCase("9/11/2016", 1, ExpectedResult = false)]
        [TestCase("10/11/2016", 1, ExpectedResult = true)]
        [TestCase("11/11/2016", 1, ExpectedResult = true)]
        [TestCase("12/11/2016", 1, ExpectedResult = false)]
        [TestCase("13/11/2016", 1, ExpectedResult = true)]
        [TestCase("14/11/2016", 1, ExpectedResult = true)]
        [TestCase("15/11/2016", 1, ExpectedResult = false)]
        [TestCase("16/11/2016", 1, ExpectedResult = false)]
        [TestCase("17/11/2016", 1, ExpectedResult = true)]
        [TestCase("18/11/2016", 1, ExpectedResult = true)]
        [TestCase("19/11/2016", 1, ExpectedResult = false)]
        [TestCase("20/11/2016", 1, ExpectedResult = true)]
        [TestCase("21/11/2016", 1, ExpectedResult = true)]
        [TestCase("22/11/2016", 1, ExpectedResult = false)]
        [TestCase("23/11/2016", 1, ExpectedResult = false)]
        [TestCase("24/11/2016", 1, ExpectedResult = true)]
        [TestCase("25/11/2016", 1, ExpectedResult = true)]
        [TestCase("26/11/2016", 1, ExpectedResult = false)]
        [TestCase("27/11/2016", 1, ExpectedResult = true)]
        [TestCase("28/11/2016", 1, ExpectedResult = true)]
        [TestCase("29/11/2016", 1, ExpectedResult = false)]
        [TestCase("30/11/2016", 1, ExpectedResult = false)]
        [TestCase("01/12/2016", 1, ExpectedResult = true)]
        [TestCase("02/12/2016", 1, ExpectedResult = true)]
        [TestCase("1/11/2016", 2, ExpectedResult = false)]
        [TestCase("2/11/2016", 2, ExpectedResult = false)]
        [TestCase("3/11/2016", 2, ExpectedResult = true)]
        [TestCase("4/11/2016", 2, ExpectedResult = true)]
        [TestCase("5/11/2016", 2, ExpectedResult = false)]
        [TestCase("6/11/2016", 2, ExpectedResult = true)]
        [TestCase("7/11/2016", 2, ExpectedResult = false)]
        [TestCase("8/11/2016", 2, ExpectedResult = false)]
        [TestCase("9/11/2016", 2, ExpectedResult = false)]
        [TestCase("10/11/2016", 2, ExpectedResult = false)]
        [TestCase("11/11/2016", 2, ExpectedResult = false)]
        [TestCase("12/11/2016", 2, ExpectedResult = false)]
        [TestCase("13/11/2016", 2, ExpectedResult = false)]
        [TestCase("14/11/2016", 2, ExpectedResult = true)]
        [TestCase("15/11/2016", 2, ExpectedResult = false)]
        [TestCase("16/11/2016", 2, ExpectedResult = false)]
        [TestCase("17/11/2016", 2, ExpectedResult = true)]
        [TestCase("18/11/2016", 2, ExpectedResult = true)]
        [TestCase("19/11/2016", 2, ExpectedResult = false)]
        [TestCase("20/11/2016", 2, ExpectedResult = true)]
        [TestCase("21/11/2016", 2, ExpectedResult = false)]
        [TestCase("22/11/2016", 2, ExpectedResult = false)]
        [TestCase("23/11/2016", 2, ExpectedResult = false)]
        [TestCase("24/11/2016", 2, ExpectedResult = false)]
        [TestCase("25/11/2016", 2, ExpectedResult = false)]
        [TestCase("26/11/2016", 2, ExpectedResult = false)]
        [TestCase("27/11/2016", 2, ExpectedResult = false)]
        [TestCase("28/11/2016", 2, ExpectedResult = true)]
        [TestCase("29/11/2016", 2, ExpectedResult = false)]
        [TestCase("30/11/2016", 2, ExpectedResult = false)]
        [TestCase("01/12/2016", 2, ExpectedResult = true)]
        [TestCase("02/12/2016", 2, ExpectedResult = true)]
        public bool TestCheckAvailabilityForWeeklyEvents(string currentDate, int frequency)
        {
            var service = new RecurrenceService();

            var model = new RecurrenceWeeklyModel
                            {
                                StartDate = DateTime.Parse("1/11/2016"),
                                EndDate = DateTime.Parse("31/1/2017"),
                                NumOfWeeks = frequency,
                                Monday = true,
                                Tuesday = false,
                                Wednesday = false,
                                Thursday = true,
                                Friday = true,
                                Saturday = false,
                                Sunday = true
            };

            var result = service.CheckAvailability(DateTime.Parse(currentDate), model);

            return result;
        }

        /// <summary>
        /// The test check availability for monthly events.
        /// </summary>
        /// <param name="currentDate">
        /// The current date.
        /// </param>
        /// <param name="dayOfMonth">
        /// The day Of Month.
        /// </param>
        /// <param name="weekdaySequence">
        /// The weekday Sequence.
        /// </param>
        /// <param name="weekday">
        /// The weekday.
        /// </param>
        /// <param name="frequency">
        /// The recurring frequency.
        /// </param>
        /// <param name="option">
        /// The option.
        /// </param>
        /// <returns>
        /// Return true if it occurs on the current date.
        /// </returns>

        // Option 1 with frequncey 1
        [TestCase("1/11/2016", 3, 0, 0, 1, 1, ExpectedResult = false)]
        [TestCase("2/11/2016", 3, 0, 0, 1, 1, ExpectedResult = false)]
        [TestCase("3/12/2016", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/1/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/2/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/3/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/4/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/5/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/6/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/7/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/8/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/9/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/10/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/11/2017", 3, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("3/12/2017", 3, 0, 0, 1, 1, ExpectedResult = false)]

        // Option 1 with frequncey 2
        [TestCase("1/11/2016", 3, 0, 0, 2, 1, ExpectedResult = false)]
        [TestCase("2/11/2016", 3, 0, 0, 2, 1, ExpectedResult = false)]
        [TestCase("3/11/2016", 3, 0, 0, 2, 1, ExpectedResult = true)]
        [TestCase("3/12/2016", 3, 0, 0, 2, 1, ExpectedResult = false)]
        [TestCase("3/1/2017", 3, 0, 0, 2, 1, ExpectedResult = true)]
        [TestCase("3/2/2017", 3, 0, 0, 2, 1, ExpectedResult = false)]
        [TestCase("3/3/2017", 3, 0, 0, 2, 1, ExpectedResult = true)]
        [TestCase("3/4/2017", 3, 0, 0, 2, 1, ExpectedResult = false)]
        [TestCase("3/5/2017", 3, 0, 0, 2, 1, ExpectedResult = true)]
        [TestCase("3/6/2017", 3, 0, 0, 2, 1, ExpectedResult = false)]
        [TestCase("3/7/2017", 3, 0, 0, 2, 1, ExpectedResult = true)]
        [TestCase("3/8/2017", 3, 0, 0, 2, 1, ExpectedResult = false)]
        [TestCase("3/9/2017", 3, 0, 0, 2, 1, ExpectedResult = true)]
        [TestCase("3/10/2017", 3, 0, 0, 2, 1, ExpectedResult = false)]
        [TestCase("3/11/2017", 3, 0, 0, 2, 1, ExpectedResult = true)]
        [TestCase("3/12/2017", 3, 0, 0, 2, 1, ExpectedResult = false)]

        // Option 2 with frequncey 1
        // every first thurday of every month
        [TestCase("1/11/2016", 0, 1, 4, 1, 2, ExpectedResult = false)]
        [TestCase("2/11/2016", 0, 1, 4, 1, 2, ExpectedResult = false)]
        [TestCase("3/11/2016", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("1/12/2016", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("5/01/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("2/02/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("2/03/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("6/04/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("04/05/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("01/06/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("06/07/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("03/08/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("07/09/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("05/10/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("02/11/2017", 0, 1, 4, 1, 2, ExpectedResult = true)]
        [TestCase("07/12/2017", 0, 1, 4, 1, 2, ExpectedResult = false)]

        // every second thurday of two months
        [TestCase("1/11/2016", 0, 2, 4, 2, 2, ExpectedResult = false)]
        [TestCase("2/11/2016", 0, 2, 4, 2, 2, ExpectedResult = false)]
        [TestCase("3/11/2016", 0, 2, 4, 2, 2, ExpectedResult = false)]
        [TestCase("10/11/2016", 0, 2, 4, 2, 2, ExpectedResult = true)]
        [TestCase("12/01/2017", 0, 2, 4, 2, 2, ExpectedResult = true)]
        [TestCase("9/03/2017", 0, 2, 4, 2, 2, ExpectedResult = true)]
        [TestCase("11/05/2017", 0, 2, 4, 2, 2, ExpectedResult = true)]
        [TestCase("13/07/2017", 0, 2, 4, 2, 2, ExpectedResult = true)]
        [TestCase("14/09/2017", 0, 2, 4, 2, 2, ExpectedResult = true)]
        [TestCase("09/11/2017", 0, 2, 4, 2, 2, ExpectedResult = true)]
        [TestCase("07/12/2017", 0, 2, 4, 2, 2, ExpectedResult = false)]
        public bool TestCheckAvailabilityForMonthlyEvents(string currentDate, int dayOfMonth, int weekdaySequence, int weekday, int frequency, int option)
        {
            var service = new RecurrenceService();

            RecurrenceMonthlyModel model;

            if (option == 1)
            {
                // Option 1
                model = new RecurrenceMonthlyModel
                                {
                                    StartDate = DateTime.Parse("01/11/2016"),
                                    EndDate = DateTime.Parse("30/11/2017"),
                                    DateOfMoth = dayOfMonth, // day of month
                                    NthWeekday = 0,
                                    Weekday = Weekdays.None,
                                    NumOfMonths = frequency, // frequency
                                };
            }
            else
            {
                // Option 2
                model = new RecurrenceMonthlyModel
                {
                    StartDate = DateTime.Parse("01/11/2016"),
                    EndDate = DateTime.Parse("30/11/2017"),
                    DateOfMoth = 0,
                    NthWeekday = (WeekdaySequences)weekdaySequence, // number of weekday
                    Weekday = (Weekdays)weekday, // weekday
                    NumOfMonths = frequency // frequency
                };
            }

            return service.CheckAvailability(DateTime.Parse(currentDate), model);
        }

        /// <summary>
        /// The test check availability for yearly events.
        /// </summary>
        /// <param name="currentDate">
        /// The current date.
        /// </param>
        /// <param name="dayOfYear">
        /// The day Of Year.
        /// </param>
        /// <param name="weekdaySequence">
        /// The weekday Sequence.
        /// </param>
        /// <param name="weekday">
        /// The weekday.
        /// </param>
        /// <param name="month">
        /// The month.
        /// </param>
        /// <param name="frequency">
        /// The frequency.
        /// </param>
        /// <param name="option">
        /// The option.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
       
        // Option 1 with frequncey 1
        [TestCase("1/11/2016", "2/11/2016", 0, 0, 0, 1, 1, ExpectedResult = false)]
        [TestCase("2/11/2016", "2/11/2016", 0, 0, 0, 1, 1, ExpectedResult = true)]
        [TestCase("2/11/2017", "2/11/2016", 0, 0, 0, 1, 1, ExpectedResult = true)]

        // Option 2 with frequncey 1
        // every second of thurday of Jan every year
        [TestCase("1/11/2016", "", 2, 4, 1, 1, 2, ExpectedResult = false)]
        [TestCase("2/11/2016", "", 2, 4, 1, 1, 2, ExpectedResult = false)]
        [TestCase("12/01/2017", "", 2, 4, 1, 1, 2, ExpectedResult = true)]
        public bool TestCheckAvailabilityForYearlyEvents(string currentDate, string dayOfYear, int weekdaySequence, int weekday, int month, int frequency, int option)
        {
            var service = new RecurrenceService();

            RecurrenceYearlyModel model;

            if (option == 1)
            {
                model = new RecurrenceYearlyModel
                {
                    StartDate = DateTime.Parse("01/11/2016"),
                    EndDate = DateTime.Parse("30/11/2017"),
                    DateOfYear = DateTime.Parse(dayOfYear), // date of year
                    NthWeekday = WeekdaySequences.None,
                    Weekday = Weekdays.None,
                    Month = Months.None,
                    NumOfYears = frequency // frequency
                };
            }
            else
            {
                model = new RecurrenceYearlyModel
                {
                    StartDate = DateTime.Parse("01/11/2016"),
                    EndDate = DateTime.Parse("30/11/2017"),
                    DateOfYear = DateTime.MinValue,
                    NthWeekday = (WeekdaySequences)weekdaySequence, // number of weekday
                    Weekday = (Weekdays)weekday, // weekday
                    Month = (Months)month, // month
                    NumOfYears = frequency // frequency
                };
            }
            
            return service.CheckAvailability(DateTime.Parse(currentDate), model);
        }
    }
}
