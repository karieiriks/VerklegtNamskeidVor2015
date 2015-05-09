using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelBookApplication.Tests.Services
{
    [TestClass]
    public class StoryServiceTest
    {
        [TestMethod]
        public void TestLeapYear()
        {
            Assert.IsTrue(isLeapYear(2012));
        }
    }
}
