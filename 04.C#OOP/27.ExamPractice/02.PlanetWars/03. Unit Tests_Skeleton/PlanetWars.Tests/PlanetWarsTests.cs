using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [SetUp]
            public void SetUp()
            {

            }

            [Test]
            public void ConstructorSetsNameProperly()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Assert.AreEqual("Asdromer", planet.Name);
            }

            [Test]
            public void ConstructorSetsBudgeProperly()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Assert.AreEqual(4500, planet.Budget);
            }

            [Test]
            public void ConstructorSetsWeaponsProperly()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [TestCase(null)]
            [TestCase("")]
            public void NullOrEmptyNameShouldThrowException(string name)
            {
                Planet planet;
                Assert.Throws<ArgumentException>(() =>
                planet = new Planet(name, 4500)
                );
            }

            [Test]
            public void NegativeBudgetThrowsException()
            {
                Planet planet;
                Assert.Throws<ArgumentException>(() =>
                planet = new Planet("Asdromer", -33)
                );
            }

            [Test]
            public void WeaponsReturnProperWeapon()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Weapon destroyer = new Weapon("Destroyer", 20, 1);
                planet.AddWeapon(destroyer);
                Assert.AreEqual(destroyer, planet.Weapons.FirstOrDefault(x => x.Name == "Destroyer"));
            }

            [Test]
            public void MilitaryPowerRatioReturnProperPower()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Weapon destroyer = new Weapon("Destroyer", 20, 1);
                Weapon destroyer2 = new Weapon("UnDestroyer", 20, 2);
                planet.AddWeapon(destroyer);
                planet.AddWeapon(destroyer2);
                Assert.AreEqual(3, planet.MilitaryPowerRatio);
            }

            [Test]
            public void ProfitIncreasesBudget()
            {
                Planet planet = new Planet("Asdromer", 4500);
                planet.Profit(1000);
                Assert.AreEqual(5500, planet.Budget);
            }

            [Test]
            public void SpendDecreasesBudget()
            {
                Planet planet = new Planet("Asdromer", 4500);
                planet.SpendFunds(1000);
                Assert.AreEqual(3500, planet.Budget);
            }

            [Test]
            public void SpendThrowsExceptionIfMoreThanBudget()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Assert.Throws<InvalidOperationException>(() =>
                planet.SpendFunds(6000)
                );
            }

            [Test]
            public void AddWeaponAddsProperWeapom()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Weapon destroyer = new Weapon("Destroyer", 20, 1);
                planet.AddWeapon(destroyer);
                Assert.AreEqual(destroyer, planet.Weapons.FirstOrDefault(x => x.Name == "Destroyer"));
            }

            [Test]
            public void AddWeaponThrowsExceptionIfAddingSameWeapon()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Weapon destroyer = new Weapon("Destroyer", 20, 1);
                planet.AddWeapon(destroyer);
                Assert.Throws<InvalidOperationException>(() =>
                planet.AddWeapon(destroyer)
                );
            }

            [Test]
            public void RemoveWeaponRemovesWeapon()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Weapon destroyer = new Weapon("Destroyer", 20, 1);
                planet.AddWeapon(destroyer);
                planet.RemoveWeapon("Destroyer");
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [Test]
            public void UpgradeWeaponUpgradesPowerOfTheWeapon()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Weapon destroyer = new Weapon("Destroyer", 20, 1);
                planet.AddWeapon(destroyer);
                planet.UpgradeWeapon("Destroyer");
                Assert.AreEqual(2, planet.Weapons.FirstOrDefault(x => x.Name == "Destroyer").DestructionLevel);
            }

            [Test]
            public void UpgradeWeaponThrowsExceptionIfNoWeaponMatch()
            {
                Planet planet = new Planet("Asdromer", 4500);
                Assert.Throws<InvalidOperationException>(() =>
                planet.UpgradeWeapon("Destroyer")
                );
            }

            [Test]
            public void DestructOpponentThrowsExceptionIfOpponentIsStronger()
            {
                Planet planet = new Planet("Asdromer", 4500);
                planet.AddWeapon(new Weapon("Destroyer", 1, 1));

                Planet planet2 = new Planet("AsdromerZer", 4500);
                planet2.AddWeapon(new Weapon("Annihilator", 2, 2));

                Assert.Throws<InvalidOperationException>(() =>
                planet.DestructOpponent(planet2)
                );
            }

            [Test]
            public void DestructOpponentDestroysOpponent()
            {
                Planet planet = new Planet("Asdromer", 4500);
                planet.AddWeapon(new Weapon("Destroyer", 1, 1));

                Planet planet2 = new Planet("AsdromerZer", 4500);
                planet2.AddWeapon(new Weapon("Annihilator", 2, 2));

                string result = planet2.DestructOpponent(planet);
                Assert.AreEqual($"{planet.Name} is destructed!", result);
            }

            [Test]
            public void ConstructorSetsWeaponNameProperly()
            {
                Weapon weapon = new Weapon("Destroyer", 10, 1);
                Assert.AreEqual("Destroyer", weapon.Name);
            }

            [Test]
            public void ConstructorSetsWeaponPriceProperly()
            {
                Weapon weapon = new Weapon("Destroyer", 10, 1);
                Assert.AreEqual(10, weapon.Price);
            }

            [Test]
            public void ConstructorSetsWeaponDestructionLevelProperly()
            {
                Weapon weapon = new Weapon("Destroyer", 10, 1);
                Assert.AreEqual(1, weapon.DestructionLevel);
            }

            [Test]
            public void PriceThrowsExceptionIfPriceIsNegative()
            {
                Weapon weapon;
                Assert.Throws<ArgumentException>(() =>
                weapon = new Weapon("Destroyer", -10, 1)
                );
            }

            [Test]
            public void IncreaseDestructionLevelIncreasesDestructionLevel()
            {
                Weapon weapon = new Weapon("Destroyer", 10, 1);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(2, weapon.DestructionLevel);
            }

            [Test]
            public void NuclearWeaponReturnTrueIf10orMoreDestructionLevel()
            {
                Weapon weapon = new Weapon("Destroyer", 10, 10);
                Assert.AreEqual(true, weapon.IsNuclear);
            }
        }
    }
}
