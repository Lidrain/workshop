using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionCS;

namespace TestProject
{
    [TestClass]
    public class DiscountTest
    {
        [TestMethod]
        public void Test1ABuy1Item()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 1;
            promo.DiscountPercent = 0.3;
            promo.MinItems = 2;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();
            
            order.Add(Products.GetProduct("blueDress"), 1);
            
            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 100.0;//TODO: set the expected value;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test1BBuy2ItemsOfSameSKU() 
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 1;
            promo.DiscountPercent = 0.3;
            promo.MinItems = 2;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();
            order.Add(Products.GetProduct("blueDress"), 2);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 100.0 + 0.7 * 100;//TODO: set the expected value;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test1CBuy2ItemsOfSameStyle()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 1;
            promo.DiscountPercent = 0.3;
            promo.MinItems = 2;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();
            order.Add(Products.GetProduct("blueDress"), 1);
            order.Add(Products.GetProduct("redDress"), 1);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 100.0 + 0.7 * 100;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test1DBuyOddNumItems()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 1;
            promo.DiscountPercent = 0.3;
            promo.MinItems = 2;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();
            order.Add(Products.GetProduct("blueDress"), 2);
            order.Add(Products.GetProduct("redDress"), 1);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 100.0 + 0.7 * 100 + 100.0;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);

            //exercise
            order.Items.Clear();
            order.Add(Products.GetProduct("blueDress"), 2);
            order.Add(Products.GetProduct("greenDress"), 2);
            order.Add(Products.GetProduct("redDress"), 1);

            newOrder = dc.CalculateDiscount(order);

            //verify
            expectedValue = 100.0 * 3 + (0.7 * 100) * 2;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test2ABuy1Item()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 2;
            promo.DiscountPercent = 0.1;
            promo.SecondDiscount = 0.2;
            promo.MinItems = 2;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();

            order.Add(Products.GetProduct("blueDress"), 1);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 100.0 * 0.9;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test2BBuy2ItemsOfSameStyle()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 2;
            promo.DiscountPercent = 0.1;
            promo.SecondDiscount = 0.2;
            promo.MinItems = 2;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();

            order.Add(Products.GetProduct("blueDress"), 2);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 2* 100.0 * 0.8;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test2CBuyMoreThan2ItemsOfSameStyle()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 2;
            promo.DiscountPercent = 0.1;
            promo.SecondDiscount = 0.2;
            promo.MinItems = 2;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();

            order.Add(Products.GetProduct("blueDress"), 1);
            order.Add(Products.GetProduct("redDress"), 1);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 2 * 100.0 * 0.8;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);

            
            order = new Order();

            order.Add(Products.GetProduct("blueDress"), 2);
            order.Add(Products.GetProduct("redDress"), 1);

            //exercise
            newOrder = dc.CalculateDiscount(order);

            //verify
            expectedValue = 3 * 100.0 * 0.8;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test2DBuy1ItemOfDifferentStyle()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 2;
            promo.DiscountPercent = 0.1;
            promo.SecondDiscount = 0.2;
            promo.MinItems = 2;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();

            order.Add(Products.GetProduct("blueDress"), 1);
            order.Add(Products.GetProduct("whiteSocks"), 1);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 100.0 * 0.9 + 10.0 * 0.9;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test2EBuyItemsOfDifferentStyle()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 2;
            promo.DiscountPercent = 0.1;
            promo.SecondDiscount = 0.2;
            promo.MinItems = 2;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();

            order.Add(Products.GetProduct("blueDress"), 2);
            order.Add(Products.GetProduct("whiteSocks"), 1);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 10.0 * 0.9 + 2*100.00 * 0.8;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test3ABuyLessThan3Socks()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 3;
            promo.DiscountPrice= 20;
            promo.MinItems = 3;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();
            order.Add(Products.GetProduct("whiteSocks"), 2);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 10.0 * 2;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test3BBuy3Socks()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 3;
            promo.DiscountPrice = 20;
            promo.MinItems = 3;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();
            order.Add(Products.GetProduct("invisibleSocks"), 3);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 25;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test3CBuyMulitple3Socks()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 3;
            promo.DiscountPrice = 20;
            promo.MinItems = 3;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();
            order.Add(Products.GetProduct("invisibleSocks"), 6);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 50;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test3DBuyMulitpleSocks()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 3;
            promo.DiscountPrice = 20;
            promo.MinItems = 3;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();
            order.Add(Products.GetProduct("invisibleSocks"), 10);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 90;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        }

        [TestMethod]
        public void Test3EBuyMixItems()
        {
            //setup
            Promotion promo = new Promotion();
            promo.DiscountScheme = 3;
            promo.DiscountPrice = 20;
            promo.MinItems = 3;

            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = new Order();
            order.Add(Products.GetProduct("invisibleSocks"), 10);
            order.Add(Products.GetProduct("blueDress"), 2);
            order.Add(Products.GetProduct("whiteSocks"), 1);

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 25*3 + 15 + 2*100.0 + 10.0;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
        } 
    }
}
