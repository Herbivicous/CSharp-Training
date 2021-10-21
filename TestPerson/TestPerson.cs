using TP.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPerson
{
    [TestClass]
    public class TestPerson
    {
        Person P;

        [TestInitialize]
        public void Init()
        {
            P = new Person("b", "c", new DateTime(1998, 3, 25));
        }

        [TestMethod]
        [DataRow(2018, 3, 20, 19)]
        [DataRow(2018, 3, 25, 20)]
        [DataRow(2018, 3, 28, 20)]
        [DataRow(2018, 2, 24, 19)]
        [DataRow(2018, 2, 25, 19)]
        [DataRow(2018, 4, 24, 20)]
        [DataRow(2018, 4, 25, 20)]
        public void TestAge(int year, int month, int day, int expectedAge) 
        {
            Assert.AreEqual(P.GetAge(new DateTime(year, month, day)), expectedAge);
        }
    }
}
