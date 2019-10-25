using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestTicketBooking
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFailParse()
        {
            List<List<string>> rows = TheaterBooking.BookingRepository.ParseLayoutAndBooking("InputWrong.txt");
            bool IsPassed = false;
            if (rows[0][0].Contains("Exception"))
            {
                IsPassed = true;
            }
            Assert.IsTrue(IsPassed);
        }
    }
}
