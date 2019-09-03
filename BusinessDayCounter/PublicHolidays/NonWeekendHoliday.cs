using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDayUtility.PublicHolidays
{
    /// <summary>
    /// Public holiday that occurs on following Monday
    /// if it falls in the weekend
    /// </summary>
    public class NonWeekendHoliday : PublicHoliday
    {
        public NonWeekendHoliday(int month, int day) : base(month, day) { }
        
        /// <summary>
        /// Get the date the public holiday will occur on a given year
        /// </summary>
        public override DateTime GetDate(int year)
        {
            DateTime holDateTime = new DateTime(year, month, day);

            if (holDateTime.DayOfWeek == DayOfWeek.Saturday)
                holDateTime = holDateTime.AddDays(2);
            else if (holDateTime.DayOfWeek == DayOfWeek.Sunday)
                holDateTime = holDateTime.AddDays(1);

            return holDateTime;
        }
    }
}
