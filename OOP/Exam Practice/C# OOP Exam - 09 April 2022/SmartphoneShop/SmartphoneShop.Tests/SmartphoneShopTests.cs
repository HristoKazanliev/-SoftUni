using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void TestSmartphoneMaximumBatteryCharge()
        {
            Smartphone smartphone = new Smartphone("X" , 4000);

            Assert.AreEqual(4000, smartphone.MaximumBatteryCharge);
        }

        [Test]
        public void TestSmartphoneCurrentBateryCharge()
        {
            Smartphone smartphone = new Smartphone("X", 4000);

            Assert.AreEqual(4000, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestShopConstructorShouldThrowExceptionWithNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-10);
            });
        }

        [Test]
        public void TestShopConstructorShouldWorkCorrectly()
        {
            Shop shop = new Shop(10);

            Assert.AreEqual(0, shop.Count);
            Assert.AreEqual(10, shop.Capacity);
        }

        [Test]
        public void TestCountPropertyShouldWorkCorrectly()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("X", 4000);
            shop.Add(smartphone);

            Assert.AreEqual(1, shop.Count);
            Assert.AreEqual(10, shop.Capacity);
        }

        [Test]
        public void TestAddMethodShouldThrowExceptionIfSmartphoneIsAlreadyAdded()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("X", 4000);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone);
            });
        }

        [Test]
        public void TestAddMethodShouldThrowExceptionIfShopCapacityIsExceeded()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("X", 4000);
            Smartphone smartphone2 = new Smartphone("S", 4000);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone2);
            });
        }

        [Test]
        public void TestAddMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("X", 4000);
            shop.Add(smartphone);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void TestRemoveMethodShouldThrowExceptionIfSmartphoneDoesNotExist()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("X", 4000);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("S");
            });
        }

        [Test]
        public void TestRemoveMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("X", 4000);
            shop.Add(smartphone);
            shop.Remove("X");

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionIfSmartphoneDoesNotExist()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("X", 4000);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("S");
            });
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionIfSmartphoneBatteryUsageIsMoreThanCurrentBateryCharge()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("X", 4000);
            shop.Add(smartphone);
            shop.TestPhone("X", 3000);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("X", 2000);
            });
        }

        [Test]
        public void TestPhoneMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("X", 4000);
            shop.Add(smartphone);
            shop.TestPhone("X", 3000);

            Assert.AreEqual(1000, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestChargePhoneMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("X", 4000);
            shop.Add(smartphone);
            shop.TestPhone("X", 1000);
            shop.ChargePhone("X");

            Assert.AreEqual(4000, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestChargePhoneMethodShouldThrowExceptionIfSmartphoneDoesNotExist()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("X", 4000);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("S");
            });
        }
    }
}