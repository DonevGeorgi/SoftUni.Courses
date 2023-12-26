using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Garage garage;

            [SetUp]
            public void SetUp()
            {
                garage = new Garage("PriJeko", 2);
            }

            [Test]
            public void ChekingIfConstructorInitializingEverythingAsIntended()
            {
                Assert.AreEqual(garage.Name,"PriJeko");
                Assert.AreEqual(garage.MechanicsAvailable, 2);
                Assert.AreEqual(garage.CarsInGarage, 0);
            }

            //[TestCase(" ")]
            //[TestCase(null)]
            //public void ChekingIfNamePropertyThrowsExceptionForNullOrEmpty(string name)
            //{
            //    ArgumentNullException exception =
            //        Assert.Throws<ArgumentNullException>(() => new Garage(name, 3));
            //    Assert.AreEqual(exception.Message, nameof(name), "Invalid garage name.");
            //}

            [Test]
            public void ChekingIfMechanicPropertyThrowsException()
            {
                ArgumentException exception =
                    Assert.Throws<ArgumentException>(() => new Garage("Niko", -3));
                Assert.AreEqual(exception.Message,"At least one mechanic must work in the garage.");
            }

            [Test]
            public void ChekingIfAddMethodAddingAsIntended()
            {
                garage.AddCar(new Car("Toyota", 2));

                Assert.AreEqual(garage.CarsInGarage,1);
            }

            [Test]
            public void TestingFixCarMethodIfWorksAsIntended()
            {
                garage.AddCar(new Car("Mazda", 2));
                Car carToFix = garage.FixCar("Mazda");

                Assert.AreEqual(carToFix.NumberOfIssues,0);
            }

            [Test]
            public void TestingMethodRemovingCarToFix()
            {
                garage.AddCar(new Car("Gold 3",0));
                garage.AddCar(new Car("Gold 2", 2));

                garage.RemoveFixedCar();

                Assert.AreEqual(garage.CarsInGarage,1);
            }

            [Test]
            public void RemovingCarToFixUntillThereAreNull()
            {
                InvalidOperationException exception =
                   Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
                Assert.AreEqual(exception.Message, "No fixed cars available.");
            }

            [Test]
            public void TestingIfCanFixNonExistingOrder()
            {
                InvalidOperationException exception =
                    Assert.Throws<InvalidOperationException>(() => garage.FixCar("Golf"));
                Assert.AreEqual(exception.Message, $"The car Golf doesn't exist.");
            }

            [Test]
            public void ChekingIfAddMethodThrowsExceptionForExeedingCapacitet()
            {
                garage.AddCar(new Car("Toyota",2));
                garage.AddCar(new Car("Mazda", 2));

                InvalidOperationException exception =
                    Assert.Throws<InvalidOperationException>(() => garage.AddCar(new Car("Gold", 2)));
                Assert.AreEqual(exception.Message, "No mechanic available.");
            }

            [Test]
            public void ChekingIfCarReportWorksFine()
            {
                garage.AddCar(new Car("Mazda", 2));
                garage.AddCar(new Car("Gold", 1));

                Assert.AreEqual(garage.Report(), "There are 2 which are not fixed: Mazda, Gold.");
            }

            [TearDown]
            public void TearDown()
            {
                garage = null;
            }
        }
    }
}