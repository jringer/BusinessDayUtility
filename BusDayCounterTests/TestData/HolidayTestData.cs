using BusinessDayUtility.PublicHolidays;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDayUtility.Tests.TestData
{
    public struct HolidayTestData
    {
        public static readonly List<DateTime> PublicHolidayDates = new List<DateTime>()
        {
            new DateTime(2013, 12, 25),
            new DateTime(2013, 12, 26),
            new DateTime(2014, 1, 1)
        };

        public static readonly List<DateTime> DupPublicHolidayDates = new List<DateTime>()
        {
            new DateTime(2013, 12, 25),
            new DateTime(2013, 12, 26),
            new DateTime(2014, 1, 1),
            new DateTime(2013, 12, 25),
            new DateTime(2013, 12, 26),
            new DateTime(2014, 1, 1)
        };

        public static readonly PublicHoliday Christmas = new PublicHoliday(12, 25);
        public static readonly PublicHoliday AnzacDay = new PublicHoliday(4, 25);
        public static readonly PublicHoliday NewYearsDay = new NonWeekendHoliday(1, 1);
        public static readonly PublicHoliday QueensBirthday = new OccurenceHoliday(6, 2, DayOfWeek.Monday);

        public static readonly List<PublicHoliday> PublicHolidays = new List<PublicHoliday>()
        {
            Christmas,
            AnzacDay,
            NewYearsDay,
            QueensBirthday
        };

    }
}
