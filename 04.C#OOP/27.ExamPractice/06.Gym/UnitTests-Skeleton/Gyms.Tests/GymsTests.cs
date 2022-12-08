namespace Gyms.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class GymsTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ConstructorShouldSetNameProperly()
        {
            Gym gym = new Gym("Agym", 5);
            Assert.AreEqual("Agym", gym.Name);
        }

        [Test]
        public void ConstructorShouldSetCapacityProperly()
        {
            Gym gym = new Gym("Agym", 5);
            Assert.AreEqual(5, gym.Capacity);
        }

        [Test]
        public void ConstructorShouldSetAtlethesListProperly()
        {
            Gym gym = new Gym("Agym", 5);
            Assert.AreEqual(0, gym.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrowExceptionWhenNullOrEmpty(string name)
        {
            Gym gym;
            Assert.Throws<ArgumentNullException>(() =>
            gym = new Gym(name, 5)
            );
        }

        [Test]
        public void CapacityShouldThrowExceptionIfLessThanZero()
        {
            Gym gym;
            Assert.Throws<ArgumentException>(() =>
            gym = new Gym("Agym", -5)
            );
        }

        [Test]
        public void CountShouldCountAthletes()
        {
            Gym gym = new Gym("Agym", 5);
            gym.AddAthlete(new Athlete("Sasho"));
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void AddAthleteShouldAddAthlete()
        {
            Gym gym = new Gym("Agym", 5);
            gym.AddAthlete(new Athlete("Sasho"));
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void AddAthleteShouldThrowExceptionIfGymIsFull()
        {
            Gym gym = new Gym("Agym", 5);
            gym.AddAthlete(new Athlete("Sasho"));
            gym.AddAthlete(new Athlete("Masho"));
            gym.AddAthlete(new Athlete("Pasho"));
            gym.AddAthlete(new Athlete("Rasho"));
            gym.AddAthlete(new Athlete("Gasho"));
            Assert.Throws<InvalidOperationException>(() =>
            gym.AddAthlete(new Athlete("Excsho"))
            );
        }

        [Test]
        public void RemoveAthleteShouldRemoveAthlete()
        {
            Gym gym = new Gym("Agym", 5);
            gym.AddAthlete(new Athlete("Sasho"));
            gym.RemoveAthlete("Sasho");
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void RemoveAthleteShouldThrowExceptionIfAtleteIsMissing()
        {
            Gym gym = new Gym("Agym", 5);
            Assert.Throws<InvalidOperationException>(() =>
            gym.RemoveAthlete("Sasho")
            );
        }

        [Test]
        public void InjureAthleteShouldInjureAthlete()
        {
            Gym gym = new Gym("Agym", 5);
            Athlete athlete = new Athlete("Sasho");
            gym.AddAthlete(athlete);
            gym.InjureAthlete("Sasho");
            Assert.AreEqual(true, athlete.IsInjured);
        }

        [Test]
        public void InjureAthleteShouldThrowExceptionIfNoSuchAthlete()
        {
            Gym gym = new Gym("Agym", 5);
            Assert.Throws<InvalidOperationException>(() =>
            gym.InjureAthlete("Sasho")
            );
        }

        [Test]
        public void ReportShouldReturnAllAtletes()
        {
            Gym gym = new Gym("Agym", 5);
            Athlete athlete = new Athlete("Sasho");
            gym.AddAthlete(athlete);
            Assert.AreEqual("Active athletes at Agym: Sasho", gym.Report());
        }

        [Test]
        public void ReportShouldNotReturnInjuredAtletes()
        {
            Gym gym = new Gym("Agym", 5);
            Athlete athlete = new Athlete("Sasho");
            Athlete athlete2 = new Athlete("Galo");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.InjureAthlete("Galo");
            Assert.AreEqual("Active athletes at Agym: Sasho", gym.Report());
        }

        [Test]
        public void ReportShouldPrintMoreThanOneAthlete()
        {
            Gym gym = new Gym("Agym", 5);
            Athlete athlete = new Athlete("Sasho");
            Athlete athlete2 = new Athlete("Galo");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            Assert.AreEqual("Active athletes at Agym: Sasho, Galo", gym.Report());
        }
    }
}
