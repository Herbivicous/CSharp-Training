using TP.BankLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP.BankLib.model;
using System;

namespace UnitTestBankOperations
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEmptyAccount()
        {
            BankAccountInfo account = new BankAccountInfo("", null);

            Assert.AreEqual(new PositiveDouble(0), account.Solde, "Not 0");
        }

        [TestMethod]
        public void TestInitAccount()
        {
            BankAccountInfo account = new BankAccountInfo("", null, DateTime.Now, new PositiveDouble(123456));

            Assert.AreEqual(new PositiveDouble(123456), account.Solde, "Not 123456");
        }

        [TestMethod]
        public void TestCrediter()
        {
            BankAccountInfo account = new BankAccountInfo("", null);
            BankAccountOperations operations = new BankAccountOperations(account);

            bool success = operations.Crediter(DateTime.Now, new PositiveDouble(123456));

            Assert.AreEqual(true, success, "Should be successful");
            Assert.AreEqual(new PositiveDouble(123456), account.Solde, "Not 123456");
        }

        [TestMethod]
        public void TestDebiter()
        {
            BankAccountInfo account = new BankAccountInfo("", null, DateTime.Now, new PositiveDouble(123456));
            BankAccountOperations operations = new BankAccountOperations(account);

            bool success = operations.Debiter(DateTime.Now, new PositiveDouble(123456));

            Assert.AreEqual(true, success, "Should be successful");
            Assert.AreEqual(new PositiveDouble(0), account.Solde, "Not 0");
        }

        [TestMethod]
        public void TestMultipleTransac()
        {
            BankAccountInfo account = new BankAccountInfo("", null, DateTime.Now, new PositiveDouble(20000));
            BankAccountOperations operations = new BankAccountOperations(account);

            operations.Debiter(DateTime.Now, new PositiveDouble(10000));
            operations.Debiter(DateTime.Now, new PositiveDouble(5000));
            operations.Crediter(DateTime.Now, new PositiveDouble(500));

            Assert.AreEqual(new PositiveDouble(5500), account.Solde, "Not 5500");
        }

        [TestMethod]
        public void TestNoNegativeSolde()
        {
            BankAccountInfo account = new BankAccountInfo("", null, DateTime.Now, new PositiveDouble(500));
            BankAccountOperations operations = new BankAccountOperations(account);

            bool success = operations.Debiter(DateTime.Now, new PositiveDouble(10000));

            Assert.AreEqual(false, success, "Should not be successful");
            Assert.AreEqual(new PositiveDouble(500), account.Solde, "Not 500");
        }
    }
}
