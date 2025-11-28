namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        Car car;

        [SetUp]

        public void SetUp()
        {
            car = new Car("Mazda", "6", 5, 50.0);
        }


        [Test]

        public void ShouldCarMakeCorrectlyWithZeroFuelAmount()
        {
            string expectedMake = "Mazda";
            string expectedModel = "6";
            double expectedFuelConsumption = 10;
            double expectedFuelCapacity = 50;


            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            Assert.IsNotNull(car);
            Assert.Zero(car.FuelAmount);
            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
        }

        [TestCase(null)]
        [TestCase("")]

        public void CarMakeShouldThrowExceptionWhenNullOrEmpty(string make)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Car(make, "6", 10, 50));

            Assert.AreEqual("Make cannot be null or empty!", ex.Message);
        }


        [TestCase(null)]
        [TestCase("")]

        public void CarModelShouldThrowExceptionWhenNullOrEmpry(string model)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Car("Mazda", model, 10, 50));

            Assert.AreEqual("Model cannot be null or empty!", ex.Message);
        }

        [TestCase(0)]
        [TestCase(-3.5)]

        public void CarFuelConsumptaionThrowExceptionWithZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car("Mazda", "6", fuelConsumption, 50);
            }, "Fuel consumption cannot be zero or negative!");
        }


        [TestCase(0)]
        [TestCase(-3.5)]

        public void CarFuelCapacityThrowExceptionWithZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car("Mazda", "6", 10, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(-0.1)]
        [TestCase(-35)]

        public void CarFuelAmountThrowExceptionWithZeroOrNegative(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car("Mazda", "6", 10, fuelAmount);
            }, "Fuel capacity cannot be negative!");
        }

        [Test]

        public void CarFuelAmountShouldThrowExceptionWhenLessThanZero()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(50000);

            }, "You don't have enough fuel to drive!");
        }

        [Test]

        public void CarDriveDecreaseFuelAmount()
        {
            var expectedFuelAmount = 49;

            car.Refuel(50);
            car.Drive(20);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        //[Test]
        //public void CarFuelAmountShouldThrowExceptionWhenLessThanZeroFuelAmount()
        //{

        //    Assert.Throws<InvalidOperationException>(() =>
        //    {
        //        car.Drive(15);

        //    }, "You don't have enough fuel to drive!");
        //}

        [TestCase(0)]
        [TestCase(-0.1)]

        public void CarFuelCannotBeRefuel(double fuel)
        {

            Assert.Throws<ArgumentException>(() =>
            {

                car.Refuel(fuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]

        public void CarRefuelShouldIncreaseFuelAmount()
        {
            double expectedResult = 20;
            car.Refuel(expectedResult);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [Test]

        public void CarRefuelShouldIncreaseFuelCapacityLimit()
        {
            double expectedResult = 50;

            car.Refuel(220);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }
    }
}