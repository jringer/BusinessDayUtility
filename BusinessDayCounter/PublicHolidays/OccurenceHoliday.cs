using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDayUtility.PublicHolidays
{
    /// <summary>
    /// Public holiday that occurs on a given weekday
    /// in a certain week of a month each year (e.g. 2nd
    /// Saturday of May)
    /// </summary>
    public class OccurenceHoliday : PublicHoliday
    {
        
        /// <summary>
        /// Week of the month when the holiday will occur
        /// </summary>
        private readonly int week;

        /// <summary>
        /// Day of the week when the holiday will occur
        /// </summary>
        private readonly DayOfWeek weekday;

        public OccurenceHoliday(int month, int week, DayOfWeek weekday)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException();

            if (week < 1 || week > 4)
                throw new ArgumentOutOfRangeException();

            this.month = month;
            this.week = week;
            this.weekday = weekday;
        }

        /// <summary>
        /// Get the date the public holiday will occur on a given year
        /// </summary>
        public override DateTime GetDate(int year)
        {
            DateTime firstDay = new DateTime(year, month, 1);

            // First weekday index of month
            int firstDayIndex = (int)firstDay.DayOfWeek;

            // Date of first occurence of specified week day in month
            firstDay = firstDay.AddDays((int)weekday - firstDayIndex);

            // If in previous month, skip to next week as first
            if (firstDay.Month != month)
                firstDay = firstDay.AddDays(7);

            day = firstDay.Day + 7 * (week - 1);

            return new DateTime(year, month, day);
        }
    }
}
