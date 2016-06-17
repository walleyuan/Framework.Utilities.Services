// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeExtensions.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the DateTimeExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Framework.Utilities.Services.Extensions
{
    using System;

    /// <summary>
    /// The date time extensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// The convert to UTC date time.
        /// </summary>
        /// <param name="dateTime">
        /// The date time.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime"/>.
        /// </returns>
        public static DateTime ConvertToGmtDateTime(this DateTime dateTime)
        {
            var gmt = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");

            DateTime gmtTime = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local, gmt);

            return TimeZoneInfo.ConvertTimeToUtc(gmtTime, gmt);
        }
    }
}