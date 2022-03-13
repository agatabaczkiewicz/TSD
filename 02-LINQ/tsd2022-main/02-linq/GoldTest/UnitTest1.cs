using NUnit.Framework;
using TSD.Linq.Task1.Lib;
using TSD.Linq.Task1.Lib.Model;
using System;
using System.Collections.Generic;
using TSD.Linq.Task1.App;

namespace GoldTest
{
    public class Tests
    {
        GoldClient goldClient;
        GoldApp goldApp;

        [SetUp]
        public void Setup()
        {
            goldClient = new GoldClient();
            goldApp = new GoldApp();    
        }

        [Test]
        public void Test1()
        {
            DateTime date1 = new DateTime(2021, 1, 1);
            DateTime date2 = new DateTime(2021, 12, 31);
            var result1 = goldApp.FindTop3HighestPrice(goldClient,3, date1, date2);
            var result = goldApp.FindTop3HighestPriceQuery(goldClient,3, date1, date2);
            Assert.AreEqual(result[0].Price, result1[0].Price);
        }

        [Test]
        public void Test2()
        {
            var result1 = goldApp.CheckIfCanEarnedQuery(goldClient);
            var result = goldApp.CheckIfCanEarned(goldClient);
            Assert.AreEqual(result[0].Price, result1[0].Price);
        }

        [Test]
        public void Test3()
        {
            DateTime date1 = new DateTime(2021, 1, 1);
            DateTime date2 = new DateTime(2021, 12, 31);
            var result1 = goldApp.FindTop3LowestPrice(goldClient,3,date1,date2);
            var result = goldApp.FindTop3LowestPriceQuery(goldClient,3, date1, date2);
            Assert.AreEqual(result[0].Price, result1[0].Price);
        }

        [Test]
        public void Test4()
        {
            var result1 = goldApp.FindSecendTenOfThePricesTop3Query(goldClient);
            var result = goldApp.FindSecendTenOfThePricesTop3(goldClient);
            Assert.AreEqual(result[0].Price, result1[0].Price);
        }

        [Test]
        public void Test5()
        {
            var result1 = goldApp.Invest(goldClient);
            var result = goldApp.InvestQuery(goldClient);
           // Assert.That(result, Is.EqualTo(result1).NoClip);
            Assert.AreEqual(result, result1);
        }
    }
}