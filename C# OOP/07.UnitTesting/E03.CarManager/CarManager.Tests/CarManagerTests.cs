namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Renault", "Megan", 5.3, 45);
        }

        [TearDown]
        public void TearDown()
        {
            car = null;
        }

        [Test]
        public void TestingMakePropertyInitialization()
        {
            Assert.AreEqual(car.Make, "Renault");
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestingIfThrowExceptionIfMakeIsNullOrEmpty(string make)
        {
            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => new Car(make, "3", 7.2, 45));
            Assert.AreEqual(exception.Message, "Make cannot be null or empty!");
        }

        [Test]
        public void TestingModelPropertyInitialization()
        {
            Assert.AreEqual(car.Model, "Megan");
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestingIfThrowExceptionIfModelIsNullOrEmpty(string model)
        {
            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => new Car("Gold", model, 7.2, 45));
            Assert.AreEqual(exception.Message, "Model cannot be null or empty!");
        }

        [Test]
        public void TestingFuelConsumptionPropertyInitialization()
        {
            Assert.AreEqual(car.FuelConsumption, 5.3);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestingIsFuelConsumptionIsThorwingExceptionIfIsNullOrNegative(double fuelConsumption)
        {
            ArgumentException exception =
               Assert.Throws<ArgumentException>(() => new Car("Gold", "3", fuelConsumption, 45));
            Assert.AreEqual(exception.Message, "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void TestingFuelCapacityPropertyInitialization()
        {
            Assert.AreEqual(car.FuelCapacity, 45);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestingIsFuelCapacityIsThorwingExceptionIfIsNullOrNegative(double fuelConsumption)
        {
            ArgumentException exception =
               Assert.Throws<ArgumentException>(() => new Car("Gold", "3", 7.2, fuelConsumption));
            Assert.AreEqual(exception.Message, "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void TestingFuelAmountPropertyInitialization()
        {
            Assert.AreEqual(car.FuelAmount, 0);
        }

        [Test]
        public void TestingConstructorPropertyInitialization()
        {
            Car currCar = new Car("Gold", "3", 7.2, 45);

            Assert.AreEqual(currCar.Make, "Gold");
            Assert.AreEqual(currCar.Model, "3");
            Assert.AreEqual(currCar.FuelConsumption, 7.2);
            Assert.AreEqual(currCar.FuelCapacity, 45);
            Assert.AreEqual(currCar.FuelAmount, 0);
        }

        [Test]
        public void TestingIfRefuelMethodRefuelingRight()
        {
            car.Refuel(15);

            Assert.AreEqual(car.FuelAmount, 15);
        }

        [Test]
        public void TestingIfRefuelMethodRefuelingRightIfExceedAmount()
        {
            car.Refuel(55);

            Assert.AreEqual(car.FuelAmount, 45);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestingIfRefuelMethodThrowsExceptionIfIsNegativeOrNull(double fuelToRefuel)
        {
            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));

            Assert.AreEqual(exception.Message, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void TestingIfDriveMethodIsAsIntended()
        {
            car.Refuel(20);
            car.Drive(10);

            Assert.AreEqual(car.FuelAmount, 19.47);
        }

        [Test]
        public void TestingIfDriveMethodThrowsExceptionForNotEnoughFuel()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => car.Drive(10));

            Assert.AreEqual(exception.Message, "You don't have enough fuel to drive!");
        }
    }
}