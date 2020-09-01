using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionSample.Models;
using PromotionSample.SalesEngine;

namespace PromotionTestProject
{
    [TestClass]
    public class UnitTest1
    {
        IndustryEngine Engine;

        public UnitTest1()
        {
            Engine = new IndustryEngine();
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<OrderItem> Orders = new List<OrderItem>
           {
               new OrderItem{ ProductName = "A", Quantity = 3},
               new OrderItem{ ProductName = "B", Quantity = 5},
               new OrderItem {ProductName = "C", Quantity=1},
               new OrderItem{ProductName ="D", Quantity =1}
           };
           Engine.CalculateOrders(Orders);

            Assert.AreEqual(Orders[0].Discountprice, 130);
            Assert.AreEqual(Orders[1].Discountprice, 120);
            Assert.AreEqual(Orders[2].Discountprice, 0);
            Assert.AreEqual(Orders[3].Discountprice, 130);
        }
    }
}
