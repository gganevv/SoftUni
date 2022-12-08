using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void ConstructorShouldInitializeNewShopWithProperLength()
        {
            Shop shop = new Shop(3);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void ConstructorShouldInitializeNewShopWithProperCapacity()
        {
            Shop shop = new Shop(3);
            Assert.AreEqual(3, shop.Capacity);
        }

        [Test]
        public void NegativeCapacityShouldThrowException()
        {
            Shop shop;
            Assert.Throws<ArgumentException>(() =>
            shop = new Shop(-1)
            );
        }

        [Test]
        public void CountShouldReturnNumberOfPhones()
        {
            Shop shop = new Shop(3);
            shop.Add(new Smartphone("Sony", 4500));
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void AddShouldAddProperPhone()
        {
            Shop shop = new Shop(3);
            shop.Add(new Smartphone("Sony", 4500));
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWithSamePhone()
        {
            Shop shop = new Shop(3);
            shop.Add(new Smartphone("Sony", 4500));
            Assert.Throws<InvalidOperationException>(() =>
            shop.Add(new Smartphone("Sony", 4500))
            );
        }

        [Test]
        public void AddShouldThrowExceptionWhenShopIsFull()
        {
            Shop shop = new Shop(3);
            shop.Add(new Smartphone("Sony", 4500));
            shop.Add(new Smartphone("Mony", 4500));
            shop.Add(new Smartphone("Bony", 4500));
            Assert.Throws<InvalidOperationException>(() =>
            shop.Add(new Smartphone("Brony", 4500))
            );
        }

        [Test]
        public void RemoveShouldRemovePhone()
        {
            Shop shop = new Shop(3);
            shop.Add(new Smartphone("Sony", 4500));
            shop.Remove("Sony");
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWithWrongPhone()
        {
            Shop shop = new Shop(3);
            Assert.Throws<InvalidOperationException>(() =>
            shop.Remove("Sony")
            );
        }

        [Test]
        public void TestPhoneShouldThrowExceptionWithWrongPhone()
        {
            Shop shop = new Shop(3);
            Assert.Throws<InvalidOperationException>(() =>
            shop.TestPhone("Sony", 1000)
            );
        }

        [Test]
        public void TestPhoneShouldThrowExceptionWithLessThanAvaibleBattery()
        {
            Shop shop = new Shop(3);
            shop.Add(new Smartphone("Sony", 4500));
            Assert.Throws<InvalidOperationException>(() =>
            shop.TestPhone("Sony", 5000)
            );
        }

        [Test]
        public void TestPhoneShouldRemoveFromBattery()
        {
            Shop shop = new Shop(3);
            Smartphone sony = new Smartphone("Sony", 4500);
            shop.Add(sony);
            shop.TestPhone("Sony", 1000);
            Assert.AreEqual(3500, sony.CurrentBateryCharge);
        }


        [Test]
        public void ChargePhoneShouldThrowExceptionWithWrongPhone()
        {
            Shop shop = new Shop(3);
            Assert.Throws<InvalidOperationException>(() =>
            shop.ChargePhone("Sony")
            );
        }

        [Test]
        public void ChargePhoneShouldChargeTheBattery()
        {
            Shop shop = new Shop(3);
            Smartphone sony = new Smartphone("Sony", 4500);
            shop.Add(sony);
            shop.TestPhone("Sony", 1000);
            shop.ChargePhone("Sony");
            Assert.AreEqual(4500, sony.CurrentBateryCharge);
        }
    }
}