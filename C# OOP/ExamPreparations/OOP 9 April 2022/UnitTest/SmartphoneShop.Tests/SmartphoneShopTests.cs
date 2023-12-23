using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone testSmartphone;
        private Shop testShop;

        [SetUp]
        public void SetUp()
        {
            testSmartphone = new Smartphone("Samsung Note 3", 2500);
            testShop = new Shop(2);
        }

        [Test]
        public void TestingCapacityPropertySet()
        {
            Assert.AreEqual(testShop.Capacity, 2);
        }

        [Test]
        public void TestingIfCapacityPropertyThrowExceptionForInvalidCapacity()
        {
            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => new Shop(-2));

            Assert.AreEqual(exception.Message, "Invalid capacity.");
        }

        [Test]
        public void TestingIfShopPhoneListIsInitializingOnCreate()
        {
            Assert.IsNotNull(testShop.Count);
        }

        [Test]
        public void TestingAddMethodInShopClass()
        {
            testShop.Add(testSmartphone);

            Assert.AreEqual(testShop.Count, 1);
        }

        [Test]
        public void TestingIfShopPhoneListAddingAsIntended()
        {
            testShop.Add(testSmartphone);
            testShop.Add(new Smartphone("Note 2", 1800));

            Assert.AreEqual(testShop.Count, 2);
        }

        [Test]
        public void TestingIfAddMethodThrowExceptionIfSamePhoneIsAdded()
        {
            testShop.Add(testSmartphone);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => testShop.Add(testSmartphone));

            Assert.AreEqual(exception.Message, "The phone model Samsung Note 3 already exist.");
        }

        [Test]
        public void TestingIfAddMethodThrowIfWeTryToAddMoreThenCapacity()
        {
            testShop.Add(testSmartphone);
            testShop.Add(new Smartphone("Samsung Note 2", 1700));

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => testShop.Add(new Smartphone("Samsung Note", 1300)));

            Assert.AreEqual(exception.Message, "The shop is full.");
        }

        [Test]
        public void ChekingIfRemoveMethodInShopClassRemovesAsIntended()
        {
            testShop.Add(testSmartphone);
            testShop.Remove(testSmartphone.ModelName);

            Assert.AreEqual(testShop.Count, 0);
        }

        [Test]
        public void ChekingIfRemoveMethodInShopThrowExceptionIfRemovePhoneThatIsNotInTheShop()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => testShop.Remove(testSmartphone.ModelName));

            Assert.AreEqual(exception.Message, "The phone model Samsung Note 3 doesn't exist.");
        }

        [Test]
        public void ChekingIfTestPhoneMethodInShopClassThrowExceptionIfSerchPhoneThatIsNotInTheShop()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => testShop.TestPhone(testSmartphone.ModelName, testSmartphone.CurrentBateryCharge));

            Assert.AreEqual(exception.Message, "The phone model Samsung Note 3 doesn't exist.");
        }

        [Test]
        public void ChekingIfTestPhoneMethodThrowExceptionIfBatteryUsageIsLow()
        {
            testShop.Add(testSmartphone);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => testShop.TestPhone(testSmartphone.ModelName, 3000));

            Assert.AreEqual(exception.Message, "The phone model Samsung Note 3 is low on batery.");
        }

        [Test]
        public void ChekingIfTestPhoneMethodWorksAsIntended()
        {
            testShop.Add(testSmartphone);

            testShop.TestPhone(testSmartphone.ModelName,1000);

            Assert.AreEqual(testSmartphone.CurrentBateryCharge,1500);
        }

        [Test]
        public void ChekingIfChargePhoneMethodWorksAsIntended()
        {
            testShop.Add(testSmartphone);

            testShop.TestPhone(testSmartphone.ModelName,1000);
            testShop.ChargePhone(testSmartphone.ModelName);

            Assert.AreEqual(testSmartphone.CurrentBateryCharge,2500);
        }

    [Test]
        public void ChekingIfChargePhoneMethodInShopClassThrowExceptionIfSerchPhoneThatIsNotInTheShop()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => testShop.ChargePhone("Samsung Note 3"));

            Assert.AreEqual(exception.Message, "The phone model Samsung Note 3 doesn't exist.");
        }

        [TearDown]
        public void TearDown()
        {
            testSmartphone = null;
        }

    }
}