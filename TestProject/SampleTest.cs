using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionCS;

namespace TestProject
{
    [TestClass]
    public class SampleTest
    {
        public Order GetOrder()
        {
            Order o = new Order();
            o.Add(Products.GetProduct("blueDress"), 1);
            o.Add(Products.GetProduct("redDress"), 1);
            o.Add(Products.GetProduct("greenDress"), 1);
            o.Add(Products.GetProduct("whiteSocks"), 1);
            o.Add(Products.GetProduct("redSocks"), 1);

            return o;
        }

        [TestMethod]
        public void TestTotalOrder()
        {
            DiscountCalculator dc = new DiscountCalculator(null);

            Order newOrder = dc.CalculateDiscount(GetOrder());

            Assert.AreEqual(320.0, newOrder.TotalPrice,0.001);
        }
    }
}
