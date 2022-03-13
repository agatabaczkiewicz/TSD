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
            var result1 = goldApp.FindTop3HighestPrice(goldClient);
            var result = goldApp.FindTop3HighestPriceQuery(goldClient);
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
            var result1 = goldApp.FindTop3LowestPrice(goldClient);
            var result = goldApp.FindTop3LowestPriceQuery(goldClient);
            Assert.AreEqual(result[0].Price, result1[0].Price);
        }

        [Test]
        public void Test4()
        {
            var result1 = goldApp.FindSecendTenOfThePricesTop3Query(goldClient);
            var result = goldApp.FindSecendTenOfThePricesTop3(goldClient);
            Assert.AreEqual(result[0].Price, result1[0].Price);
        }
    }
}