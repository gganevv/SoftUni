using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            [SetUp]
            public void SetUp() 
            {

            }

            [Test]
            public void ConstructorSetsProperName()
            {
                Garage garage = new Garage("AliGaraji", 3);
                Assert.AreEqual("AliGaraji", garage.Name);
            }

            [Test]
            public void ConstructorSetsProperNuberOfMechanics()
            {
                Garage garage = new Garage("AliGaraji", 3);
                Assert.AreEqual(3, garage.MechanicsAvailable);
            }

            [Test]
            public void ConstructorInitializesListOfCars()
            {
                Garage garage = new Garage("AliGaraji", 3);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [TestCase(null)]
            [TestCase("")]
            public void InvalidGarageNameShouldThrowException(string name)
            {
                Garage garage;
                Assert.Throws<ArgumentNullException>(() =>
                garage = new Garage(name, 3)
                );
            }

            [TestCase(0)]
            [TestCase(-150)]
            public void InvalidNumberOfmechanicsShouldThrowException(int numberOfMechanics)
            {
                Garage garage;
                Assert.Throws<ArgumentException>(() =>
                garage = new Garage("AliGaraji", numberOfMechanics)
                );
            }

            [Test]
            public void CarsInGarageShouldReturnNumberOfCarsInGarage()
            {
                Garage garage = new Garage("AliGaraji", 3);
                garage.AddCar(new Car("Opel", 3));
                garage.AddCar(new Car("Ferrari", 333));
                Assert.AreEqual(2, garage.CarsInGarage);
            }

            [Test]
            public void AddCarShouldAddCarToGarage()
            {
                Garage garage = new Garage("AliGaraji", 3);
                garage.AddCar(new Car("Opel", 3));
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void AddCarShouldThrowExceptionWhenCarsAreMoreThanMechanics()
            {
                Garage garage = new Garage("AliGaraji", 3);
                garage.AddCar(new Car("Opel", 3));
                garage.AddCar(new Car("Zlopel", 3));
                garage.AddCar(new Car("Moskvich", 3));
                Assert.Throws<InvalidOperationException>(() => 
                garage.AddCar(new Car("BMW", 2))
                );
            }

            [Test]
            public void FixCarShouldThrowExceptionWhenCarDoesntExcist()
            {
                Garage garage = new Garage("AliGaraj", 2);
                Assert.Throws<InvalidOperationException>(() =>
                garage.FixCar("BMAudi")
                );
            }

            [Test]
            public void FixCarShouldFixAllCarIssuesIfCarExist()
            {
                Garage garage = new Garage("AliGaraj", 2);
                Car bmw = new Car("Bmw", 2);
                garage.AddCar(bmw);
                garage.FixCar("Bmw");
                Assert.AreEqual(true, bmw.IsFixed);
            }

            [Test]
            public void RemoveFixedCarsShouldThrowExceptionWhenNoFixedCarsExist()
            {
                Garage garage = new Garage("AliGaraj", 2);
                Car bmw = new Car("Bmw", 2);
                garage.AddCar(bmw);
                Assert.Throws<InvalidOperationException>(() => 
                garage.RemoveFixedCar()
                );
            }

            [Test]
            public void RemoveFixedCarsShouldRemoveAllFixedCars()
            {
                Garage garage = new Garage("AliGaraj", 2);
                Car bmw = new Car("Bmw", 2);
                Car audi = new Car("Audi", 2);
                garage.AddCar(bmw);
                garage.AddCar(audi);
                garage.FixCar("Audi");
                int numberOfFixedCars = garage.RemoveFixedCar();
                Assert.AreEqual(1, numberOfFixedCars);
            }

            [Test]
            public void ReportShouldReturnUnfixedCars()
            {
                Garage garage = new Garage("AliGaraj", 2);
                Car bmw = new Car("Bmw", 2);
                Car audi = new Car("Audi", 2);
                garage.AddCar(bmw);
                garage.AddCar(audi);
                garage.FixCar("Audi");
                string report = garage.Report();
                string expectedReport = $"There are 1 which are not fixed: Bmw.";
                Assert.AreEqual(expectedReport, report);
            }
        }
    }
}