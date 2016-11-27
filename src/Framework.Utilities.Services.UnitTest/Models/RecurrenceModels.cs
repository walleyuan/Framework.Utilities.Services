// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecurrenceModels.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   The recurrence daily models.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.UnitTest.Models
{
    using System;
    using System.Collections.Generic;
    using Framework.Utilities.Services.Enums;
    using Framework.Utilities.Services.Models;

    /// <summary>
    /// The recurrence daily models.
    /// </summary>
    public static class RecurrenceModels
    {
        /// <summary>
        /// The recurrence daily models.
        /// </summary>
        /// <returns>
        /// The daily models.
        /// </returns>
        public static List<RecurrenceDailyModel> GetDailyModels()
        {
            return
                new List<RecurrenceDailyModel>
                             {
                                // recur every day.
                                 new RecurrenceDailyModel
                                     {
                                        StartDate = DateTime.Parse("02/08/2016"),
                                        EndDate = DateTime.Parse("02/08/2017"),
                                        Days = 1
                                     },

                                // recur every 2 days.
                                new RecurrenceDailyModel
                                     {
                                        StartDate = DateTime.Parse("02/08/2016"),
                                        EndDate = DateTime.Parse("02/08/2017"),
                                         Days = 2
                                     },

                                // recur every 3 days.
                                 new RecurrenceDailyModel
                                     {
                                        StartDate = DateTime.Parse("02/08/2016"),
                                        EndDate = DateTime.Parse("02/08/2017"),
                                        Days = 3
                                     },

                                 // recur every 14 days.
                                 new RecurrenceDailyModel
                                     {
                                        StartDate = DateTime.Parse("02/08/2016"),
                                        EndDate = DateTime.Parse("02/08/2017"),
                                        Days = 14
                                     }
                             };
        }

        /// <summary>
        /// The get weekly models.
        /// </summary>
        /// <returns>
        /// The weekly models.
        /// </returns>
        public static List<RecurrenceWeeklyModel> GetWeeklyModels()
        {
            return new List<RecurrenceWeeklyModel>
                                    {
                                        // recur on Monday every week.
                                        new RecurrenceWeeklyModel
                                            {
                                                StartDate = DateTime.Parse("1/11/2016"),
                                                EndDate = DateTime.Parse("31/1/2017"),
                                                NumOfWeeks = 1,
                                                Monday = true,
                                                Tuesday = false,
                                                Wednesday = false,
                                                Thursday = true,
                                                Friday = true,
                                                Saturday = false,
                                                Sunday = false
                                            },
                                        
                                        // recur on Monday and Friday every week.
                                        new RecurrenceWeeklyModel
                                            {
                                                StartDate = DateTime.Parse("02/08/2016"),
                                                EndDate = DateTime.Parse("02/08/2017"),
                                                NumOfWeeks = 1,
                                                Monday = true,
                                                Tuesday = false,
                                                Wednesday = false,
                                                Thursday = false,
                                                Friday = true,
                                                Saturday = false,
                                                Sunday = false
                                            },

                                         // recur on Thursday and Friday every 2 weeks.
                                        new RecurrenceWeeklyModel
                                            {
                                                StartDate = DateTime.Parse("02/08/2016"),
                                                EndDate = DateTime.Parse("02/08/2017"),
                                                NumOfWeeks = 2,
                                                Monday = false,
                                                Tuesday = false,
                                                Wednesday = false,
                                                Thursday = true,
                                                Friday = true,
                                                Saturday = false,
                                                Sunday = false
                                            }
                                    };
        }

        /// <summary>
        /// The get monthly models.
        /// </summary>
        /// <returns>
        /// The monthly models.
        /// </returns>
        public static List<RecurrenceMonthlyModel> GetMonthlyModels()
        {
            return new List<RecurrenceMonthlyModel>
                       {
                           // recur 18th ervery month.
                           new RecurrenceMonthlyModel
                               {
                                   StartDate = DateTime.Parse("02/08/2016"),
                                   EndDate = DateTime.Parse("02/08/2017"),
                                   NumOfMonths = 1,
                                   DateOfMoth = 18,
                                   NthWeekday = 0,
                                   Weekday = Weekdays.None
                               },

                            // recur 20th ervery 2 month.
                             new RecurrenceMonthlyModel
                               {
                                   StartDate = DateTime.Parse("02/08/2016"),
                                   EndDate = DateTime.Parse("02/08/2017"),
                                   NumOfMonths = 2,
                                   DateOfMoth = 20,
                                   NthWeekday = 0,
                                   Weekday = Weekdays.None
                               },
                            
                             // recur second Monday every 2 months.
                             new RecurrenceMonthlyModel
                               {
                                   StartDate = DateTime.Parse("02/08/2016"),
                                   EndDate = DateTime.Parse("02/08/2017"),
                                   NumOfMonths = 2,
                                   DateOfMoth = 0,
                                   NthWeekday = WeekdaySequences.Second,
                                   Weekday = Weekdays.Monday
                               },

                             // recur last Friday ervery 2 month.
                             new RecurrenceMonthlyModel
                               {
                                   StartDate = DateTime.Parse("02/08/2016"),
                                   EndDate = DateTime.Parse("02/08/2017"),
                                   NumOfMonths = 2,
                                   DateOfMoth = 0,
                                   NthWeekday = WeekdaySequences.Last,
                                   Weekday = Weekdays.Friday
                               }
                       };
        }

        /// <summary>
        /// The get yearly models.
        /// </summary>
        /// <returns>
        /// The yearly models.
        /// </returns>
        public static List<RecurrenceYearlyModel> GetYearlyModels()
        {
            return new List<RecurrenceYearlyModel>
                       {  
                          // recur 28/10 yearly.
                          new RecurrenceYearlyModel
                              {
                                  StartDate = DateTime.Parse("02/08/2016"),
                                  EndDate = DateTime.Parse("02/08/2029"),
                                  DateOfYear = DateTime.Parse("28/10/2016"),
                                  NthWeekday = WeekdaySequences.None,
                                  Weekday = Weekdays.None,
                                  Month = Months.None,
                                  NumOfYears = 1
                              },

                          // recur 11/09 every 2 year.
                          new RecurrenceYearlyModel
                              {
                                  StartDate = DateTime.Parse("02/08/2016"),
                                  EndDate = DateTime.Parse("02/08/2029"),
                                  DateOfYear = DateTime.Parse("11/09/2016"),
                                  NthWeekday = WeekdaySequences.None,
                                  Weekday = Weekdays.None,
                                  Month = Months.None,
                                  NumOfYears = 2
                              },

                          // recur on last friday of october every year.
                          new RecurrenceYearlyModel
                              {
                                  StartDate = DateTime.Parse("02/08/2016"),
                                  EndDate = DateTime.Parse("02/08/2029"),
                                  DateOfYear = DateTime.MinValue,
                                  NthWeekday = WeekdaySequences.Last,
                                  Weekday = Weekdays.Friday,
                                  Month = Months.October,
                                  NumOfYears = 1
                              },

                          // recur on second sunday of april every 2 years.
                          new RecurrenceYearlyModel
                              {
                                  StartDate = DateTime.Parse("02/08/2016"),
                                  EndDate = DateTime.Parse("02/08/2029"),
                                  DateOfYear = DateTime.MinValue,
                                  NthWeekday = WeekdaySequences.Second,
                                  Weekday = Weekdays.Sunday,
                                  Month = Months.April,
                                  NumOfYears = 2
                              },
                       };
        }
    }
}
