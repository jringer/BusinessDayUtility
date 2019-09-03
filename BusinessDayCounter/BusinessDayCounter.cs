using BusinessDayUtility.Extensions;
using BusinessDayUtility.PublicHolidays;
using System;
using System.Collections.Generic;

namespace BusinessDayUtility
{
    /// <summary>
    /// Counts weekdays and business days between a provided range
    /// </summary>
    public class BusinessDayCounter
    {

        /// <summary>
        /// Returns the number of weekdays between two dates
        /// </summary>
        public static int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            TimeSpan timeSpan = secondDate.Subtract(firstDate);

            // Subtract 1 because looking at exclusive range between dates
            int totalDays = Math.Max(0, (timeSpan.Days - 1));

            // 5 days for each complete week
            int weekdays = (totalDays / 7) * 5;

            int remainingDays = totalDays % 7;

            for (int i = 1; i < remainingDays + 1; i++)
            {
                if (!firstDate.AddDays(i).IsWeekend())
                    weekdays++;
            }

            return weekdays;
        }

        /// <summary>
        /// Returns the number of business days between two dates
        /// using a list of public holidays
        /// </summary>
        public static int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            int businessDays = WeekdaysBetweenTwoDates(firstDate, secondDate);

            HashSet<DateTime> visitedDates = new HashSet<DateTime>();

            // Loop over public holidays and remove if within range and is unvisited weekday
            foreach (DateTime publicHoliday in publicHolidays)
            {
                if (!publicHoliday.IsWeekend() && publicHoliday > firstDate && publicHoliday < secondDate && !visitedDates.Contains(publicHoliday))
                {
                    visitedDates.Add(publicHoliday);
                    businessDays--;
                }
            }

            return businessDays;
        }

        /// <summary>
        /// Returns the number of business days between two dates
        /// using a list of public holiday rules
        /// </summary>
        public static int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<PublicHoliday> publicHolidays)
        {
            // Store one datetime object per public holiday per year within range
            DateTime[] pubHolDates = new DateTime[(Math.Max(0, secondDate.Year - firstDate.Year) + 1) * publicHolidays.Count];

            int i = 0;
            for (int year = firstDate.Year; year <= secondDate.Year; year++)
            {
                foreach (PublicHoliday publicHoliday in publicHolidays)
                {
                    pubHolDates[i] = publicHoliday.GetDate(year);
                    i++;
                }
            }

            return BusinessDaysBetweenTwoDates(firstDate, secondDate, pubHolDates);
        }
    }
}