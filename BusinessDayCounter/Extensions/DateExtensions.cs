using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDayUtility.Extensions
{
    public static class DateExtensions
    {
        /// <summary>
        /// Returns whether datetime occurs on a weekend
        /// </summary>
        public static bool IsWeekend(this DateTime day)
        {
            return day.DayOfWeek == DayOfWeek.Sunday || day.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
