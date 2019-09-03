using BusinessDayUtility.PublicHolidays;
using BusinessDayUtility.Tests.TestData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessDayUtility.Tests
{
    public class BusinessDayCounterTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void CountWeekdays_EqualDate_ReturnZero()
        {
            Assert.AreEqual(0, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 7)));
        }

        [TestCase]
        public void CountWeekdays_NegativeRange_ReturnZero()
        {
            Assert.AreEqual(0, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5)));
        }

        [TestCase]
        public void CountWeekdays_ValidInput_Calculated()
        {
            Assert.AreEqual(5, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14)));

            Assert.AreEqual(0, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2019, 10, 25), new DateTime(2019, 10, 28)));

            Assert.AreEqual(1, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9)));

            Assert.AreEqual(5, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14)));

            Assert.AreEqual(61, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1)));

            Assert.AreEqual(4, BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2015, 1, 8), new DateTime(2015, 1, 15)));
        }

        [TestCase]
        public void CountBusinessDays_ValidInput_Calculated()
        {
            Assert.AreEqual(1, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), HolidayTestData.PublicHolidayDates));

            Assert.AreEqual(0, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 12, 24), new DateTime(2013, 12, 27), HolidayTestData.PublicHolidayDates));

            Assert.AreEqual(59, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), HolidayTestData.PublicHolidayDates));
        }

        [TestCase]
        public void CountBusinessDays_DuplicateHolidays_DuplicateIgnored()
        {
            Assert.AreEqual(1, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), HolidayTestData.DupPublicHolidayDates));

            Assert.AreEqual(0, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 12, 24), new DateTime(2013, 12, 27), HolidayTestData.DupPublicHolidayDates));

            Assert.AreEqual(59, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), HolidayTestData.DupPublicHolidayDates));
        }

        [TestCase]
        public void CountBusinessDayRules_ValidInput_Calculated()
        {
            Assert.AreEqual(0, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2015, 12, 24), new DateTime(2015, 12, 26), HolidayTestData.PublicHolidays));

            Assert.AreEqual(257, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2014, 12, 31), new DateTime(2015, 12, 31), HolidayTestData.PublicHolidays));

            Assert.AreEqual(83, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2017, 12, 31), new DateTime(2018, 4, 28), HolidayTestData.PublicHolidays));

            Assert.AreEqual(4, BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2015, 12, 24), new DateTime(2016, 1, 2), HolidayTestData.PublicHolidays));
        }

    }
}
 
 
 