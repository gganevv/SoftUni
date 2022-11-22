using CarManager;
using NUnit.Framework;
using System;
using System.Runtime.ConstrainedExecution;

namespace Carmanager.Tests
{
    [TestFixture]
    public class CarManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorSetsDefaultFuelTo0()
        {
            Car car = new Car("Vw", "Golf", 5, 45);
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void ConstructorInitilizesCarWithProperData()
        {
            Car car = new Car("Vw", "Golf", 5, 45);
            Assert.IsNotNull(car);
        }



        [Test]
        public void InvalidMakeThrowsException()
        {
            Car car;
            Assert.Throws<ArgumentException>(() =>
            car = new Car(null, "Golf", 5, 50)
            );
        }


        [Test]
        public void ValidMakeSetsMakeRight()
        {
            Car car = new Car("VW", "Golf", 5, 50);
            Assert.That(car.Make, Is.EqualTo("VW"));
        }

        [Test]
        public void InvalidModelThrowsException()
        {
            Car car;
            Assert.Throws<ArgumentException>(() =>
            car = new Car("VW", null, 5, 50)
            );
        }

        [Test]
        public void ValidModelSetsModelRight()
        {
            Car car = new Car("VW", "Golf", 5, 50);
            Assert.That(car.Model, Is.EqualTo("Golf"));
        }

        [Test]
        public void InvalidFuelConsumptionThrowsException()
        {
            Car car;
            Assert.Throws<ArgumentException>(() =>
            car = new Car("VW", "Golf", -5, 50)
            );
        }

        [Test]
        public void ValidFuelConsumptionSetsFuelConsumptionRight()
        {
            Car car = new Car("VW", "Golf", 5, 50);
            Assert.That(car.FuelConsumption, Is.EqualTo(5));
        }

        [Test]
        public void InvalidFuelCapacityThrowsException()
        {
            Car car;
            Assert.Throws<ArgumentException>(() =>
            car = new Car("VW", "Golf", 5, -50)
            );
        }

        [Test]
        public void ValidFuelCapacitySetsFuelCapacityRight()
        {
            Car car = new Car("VW", "Golf", 5, 50);
            Assert.That(car.FuelCapacity, Is.EqualTo(50));
        }

        [Test]
        public void RefuelNegativeFuelShouldThrowException()
        {
            Car car = new Car("VW", "Golf", 5, 50);
            Assert.Throws<ArgumentException>(() =>
            car.Refuel(-5)
            );
        }

        [Test]
        public void RefuelZeroFuelShouldThrowException()
        {
            Car car = new Car("VW", "Golf", 5, 50);
            Assert.Throws<ArgumentException>(() =>
            car.Refuel(0)
            );
        }

        [Test]
        public void RefuelWithProperDataShouldRefuel()
        {
            Car car = new Car("VW", "Golf", 5, 50);
            car.Refuel(5);
            Assert.That(car.FuelAmount, Is.EqualTo(5));
        }

        [Test]
        public void RefuelMoreFuelThanCapacityShouldRefuelOnlyTheMaximumCapacity()
        {
            Car car = new Car("VW", "Golf", 5, 50);
            car.Refuel(55);
            Assert.That(car.FuelAmount, Is.EqualTo(50));
        }

        [Test]
        public void DriveWithEnoughFuelShouldReduceTheFuel()
        {
            Car car = new Car("VW", "Golf", 5, 50);
            car.Refuel(50);
            car.Drive(100);
            Assert.That(car.FuelAmount, Is.EqualTo(45));
        }

        [Test]
        public void DriveWithountEnoughFuelShouldThrowException()
        {
            Car car = new Car("VW", "Golf", 5, 50);
            car.Refuel(4);
            Assert.Throws<InvalidOperationException>(() =>
            car.Drive(100)
            );
        }
    }
}