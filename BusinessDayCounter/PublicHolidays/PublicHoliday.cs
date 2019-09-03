using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDayUtility.PublicHolidays
{
    /// <summary>
    /// Public holiday that occurs on an exact date each year
    /// </summary>
    public class PublicHoliday
    {
        /// <summary>
        /// Month public holiday occurs in
        /// </summary>
        protected int month;

        /// <summary>
        /// Day public holiday occurs on (unless otherwise
        /// specified via rules)
        /// </summary>
        protected int day;

        public PublicHoliday() { }

        public PublicHoliday(int month, int day)
        {
            this.month = month;
            this.day = day;
        }

        /// <summary>
        /// Get the date the public holiday will occur on a given year
        /// </summary>
        public virtual DateTime GetDate(int year)
        {
            return new DateTime(year, month, day);
        }

    }
}
