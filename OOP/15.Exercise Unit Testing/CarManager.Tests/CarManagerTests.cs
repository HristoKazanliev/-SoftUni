namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void ConstructorShouldSetFuelAmountTo0()
        {
            Car car = new Car("BMW", "520", 13.5, 66);

            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakePropertyShouldThrowExceptionWithInvalidData(string data)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(data, "520", 13.5, 66);
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelPropertyShouldThrowExceptionWithInvalidData(string data)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", data, 13.5, 66);
            });
        }

        [Test]
        [TestCase(-10.5)]
        [TestCase(0)]
        public void FuelConsumptionPropertyShouldThrowExceptionWhenValueIsLessThan0(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "520", fuelConsumption, 66);
            });
        }

        [Test]
        [TestCase(-1.5)]
        [TestCase(0)]
        public void FuelCapacityPropertyShouldThrowExceptionWhenValueIsLessThan0(double data)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "520", -10.5, data);
            });
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Car car = new Car("BMW", "520", 10.5, 66);

            Assert.AreEqual(("BMW", "520", 10.5, 66), (car.Make, car.Model, car.FuelConsumption, car.FuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelMethodShouldThrowExceptionWhenFuelIsLessOrEqualTo0(double fuelToRefuel)
        {
            Car car = new Car("BMW", "520", 10, 60);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });
        }

        [Test]
        [TestCase(60)]
        [TestCase(70)]
        public void RefuelMethodShouldReturnFullCapacityWhenFuelAmountExceedsFuelCapacity(double fuelToRefuel)
        {
            Car car = new Car("BMW", "520", 10, 60);
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionWhenFuelIsNotEnough()
        {
            Car car = new Car("BMW", "520", 13.5, 60);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(10);
            });
        }

        [Test]
        public void DriveMethodShouldWotkCorrectly()
        {
            Car car = new Car("BMW", "520", 13.5, 60);
            car.Refuel(50);
            car.Drive(50);
            //car.FuelAmount - (50/100)*car.FuelConsumption
            Assert.AreEqual(43.25, car.FuelAmount);
        }
    }
}