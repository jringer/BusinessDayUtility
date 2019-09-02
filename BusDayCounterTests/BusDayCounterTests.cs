using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class BusDayCounterTests
    {
        List<DateTime> publicHolidays = new List<DateTime>()
        {
            new DateTime(2013, 12, 25),
            new DateTime(2013, 12, 26),
            new DateTime(2014, 1, 1)
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestWeekdaysEqual()
        {
            // 7th October 2013 - 7th October 2013 should have 0 weekdays
            Assert.AreEqual(0, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 7)));
        }

        [Test]
        public void TestWeekdaysNegativeRange()
        {
            // 7th October 2013 - 5th October 2013 should have 0 weekdays
            Assert.AreEqual(0, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5)));
        }

        [Test]
        public void TestWeekdaysStandardRange()
        {
            // 25th October 2013 - 28th October 2013 should have 0 weekdays
            Assert.AreEqual(0, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2019, 10, 25), new DateTime(2019, 10, 28)));

            // 7th October 2013 - 9th October 2013 should have 1 weekday
            Assert.AreEqual(1, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9)));

            // 5th October 2013 - 14th October 2013 should have 5 weekdays
            Assert.AreEqual(5, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14)));

            // 7th October 2013 - 1st January 2014 should have 61 weekdays
            Assert.AreEqual(61, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1)));
        }

        /*
         * SAMPLE TESTS:
         * 
            Start Date End Date Result
            7th October 2013 9th October 2013 1
            24th December 2013 27th December 2013 0
            7th October 2013 1st January 2014 59
        */
        [Test]
        public void TestBusinessDays()
        {
            // 7th October 2013 - 9th October 2013 should have 1 business day
            Assert.AreEqual(1, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), publicHolidays));

            // 24th December 2013 - 27th December 2013 should have 0 business days
            Assert.AreEqual(0, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 12, 24), new DateTime(2013, 12, 27), publicHolidays));

            // 7th October 2013 - 1st January 2014 should have 59 business days
            Assert.AreEqual(59, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), publicHolidays));

        }

    }
}
 
 
 