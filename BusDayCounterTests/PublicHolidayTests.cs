using BusinessDayUtility.PublicHolidays;
using NUnit.Framework;
using System;

namespace Tests
{
    class PublicHolidayTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void CreatePublicHolidayDate_InvalidInput_OutBoundException()
        {
            Assert.That(() => new PublicHoliday(14, 5),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => new PublicHoliday(0, 5),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => new PublicHoliday(14, 0),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => new PublicHoliday(12, 40),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase]
        public void CreateOccurenceHolidayDate_InvalidInput_OutBoundException()
        {
            Assert.That(() => new OccurenceHoliday(4, 5, DayOfWeek.Monday),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => new OccurenceHoliday(12, 0, DayOfWeek.Wednesday),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => new OccurenceHoliday(0, 3, DayOfWeek.Monday),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => new OccurenceHoliday(1, 0, DayOfWeek.Monday),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase]
        public void GetPublicHolidayDate_ValidInput_Calculated()
        {
            Assert.AreEqual(new DateTime(2012, 2, 2), new PublicHoliday(2, 2).GetDate(2012));

            Assert.AreEqual(new DateTime(2019, 9, 2), new PublicHoliday(9, 2).GetDate(2019));

            Assert.AreEqual(new DateTime(2015, 5, 25), new PublicHoliday(5, 25).GetDate(2015));
        }

        [TestCase]
        public void GetNonWeekendHolidayDate_ValidInput_Calculated()
        {
            Assert.AreEqual(new DateTime(2016, 10, 10), new NonWeekendHoliday(10, 8).GetDate(2016));

            Assert.AreEqual(new DateTime(2016, 10, 10), new NonWeekendHoliday(10, 9).GetDate(2016));

            Assert.AreEqual(new DateTime(2017, 1, 2), new NonWeekendHoliday(12, 31).GetDate(2016));
        }

        [TestCase]
        public void GetOccuranceHolidayDate_ValidInput_Calculated()
        {
            // 2nd Monday of May 2018 should be 14/05/2018
            Assert.AreEqual(new DateTime(2018, 5, 14), new OccurenceHoliday(5, 2, DayOfWeek.Monday).GetDate(2018));

            // 1st Saturday of July 2018 should be 07/07/2018
            Assert.AreEqual(new DateTime(2018, 7, 7), new OccurenceHoliday(7, 1, DayOfWeek.Saturday).GetDate(2018));

            // 4th Saturday of February 2015 should be 28/02/2015
            Assert.AreEqual(new DateTime(2015, 2, 28), new OccurenceHoliday(2, 4, DayOfWeek.Saturday).GetDate(2015));

            // 1st Friday of March 2013 should be 01/03/2013
            Assert.AreEqual(new DateTime(2013, 3, 1), new OccurenceHoliday(3, 1, DayOfWeek.Friday).GetDate(2013));
        }

    }
}
