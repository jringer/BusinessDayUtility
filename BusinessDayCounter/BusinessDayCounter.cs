using System;
using System.Collections.Generic;

public class BusinessDayCounter
{

    private static bool IsWeekend(int dateIndex)
    {
        return dateIndex == 0 || dateIndex == 6;
    }
    
    public static int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
    {
        return BusinessDaysBetweenTwoDates(firstDate, secondDate, new List<DateTime>());
    }

    public static int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
    {
        TimeSpan timeSpan = secondDate.Subtract(firstDate);

        // Subtract 1 because looking at exclusive range between dates
        int totalDays = Math.Max(0, (timeSpan.Days - 1));

        // 5 days for each complete week plus remaining days
        int businessDays = ((totalDays / 7) * 5) + totalDays % 7;

        if (totalDays > 0)
        {
            int firstDayIndex = ((int)firstDate.DayOfWeek + 1) % 6;
            int lastDayIndex = (int)secondDate.DayOfWeek - 1;

            // Remove a weekday if first day in range is Sunday or last day is Saturday
            if (IsWeekend(firstDayIndex))
                businessDays--;
            if (IsWeekend(lastDayIndex))
                businessDays--;
        }

        // Loop over public holidays and remove if with range and not weekend
        foreach (DateTime publicHoliday in publicHolidays)
        {
            int pubHolDayIndex = (int)publicHoliday.DayOfWeek;

            if (!IsWeekend(pubHolDayIndex) && publicHoliday > firstDate && publicHoliday < secondDate)
                businessDays--;
        }

        return businessDays;
    }

}
