using NUnit.Framework;
using System;

namespace Tests
{
    public class BusDayCounterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
         * SAMPLE TESTS:
         * 
            Start Date End Date Result
            7th October 2013 9th October 2013 1
            5th October 2013 14th October 2013 5
            7th October 2013 1st January 2014 61
            7th October 2013 5th October 2013 0
        */
        [Test]
        public void TestWeekdays()
        {
            // 7th October 2013 - 9th October 2013 should have 1 weekday
            Assert.AreEqual(1, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9)));

            // 5th October 2013 - 14th October 2013 should have 5 weekdays
            Assert.AreEqual(5, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14)));

            // 7th October 2013 - 1st January 2014 should have 61 weekdays
            Assert.AreEqual(61, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1)));

            // 7th October 2013 - 5th October 2013 should have 0 weekdays
            Assert.AreEqual(0, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5)));

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
            Assert.AreEqual(1, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9)));

            // 24th December 2013 - 27th December 2013 should have 0 business days
            Assert.AreEqual(0, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 12, 24), new DateTime(2013, 12, 27)));

            // 7th October 2013 - 1st January 2014 should have 59 business days
            Assert.AreEqual(59, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1)));

        }

    }
}
 
 
 