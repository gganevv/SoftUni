using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanInitializeWarrior()
        {
            Warrior warrior = new Warrior("Pesho", 50, 50);
            Assert.IsNotNull(warrior);
        }

        [Test]
        public void InitializeWarriorWithInvalidNameShouldThrowException()
        {
            Warrior warrior;
            Assert.Throws<ArgumentException>(() =>
            warrior = new Warrior(null, 50, 50)
            );
        }

        [Test]
        public void InitializeWarriorWithInvalidDamageShouldThrowException()
        {
            Warrior warrior;
            Assert.Throws<ArgumentException>(() =>
            warrior = new Warrior("Pesho", 0, 50)
            );
        }

        [Test]
        public void InitializeWarriorWithNegativeDamageShouldThrowException()
        {
            Warrior warrior;
            Assert.Throws<ArgumentException>(() =>
            warrior = new Warrior("Pesho", -5, 50)
            );
        }

        [Test]
        public void InitializeWarriorWithInvalidHPShouldThrowException()
        {
            Warrior warrior;
            Assert.Throws<ArgumentException>(() =>
            warrior = new Warrior("Pesho", 50, -10)
            );
        }

        [Test]
        public void AtackWithLowHPShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 10, 30);
            Warrior warrior2 = new Warrior("Ivan", 10, 50);
            Assert.Throws<InvalidOperationException>(() =>
            warrior.Attack(warrior2)
            );
        }

        [Test]
        public void AtackEnemyWithLowHPShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 10, 30);
            Warrior warrior2 = new Warrior("Ivan", 10, 50);
            Assert.Throws<InvalidOperationException>(() =>
            warrior2.Attack(warrior)
            );
        }

        [Test]
        public void AtackStrongerEnemyShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 35, 35);
            Warrior warrior2 = new Warrior("Ivan", 50, 50);
            Assert.Throws<InvalidOperationException>(() =>
            warrior.Attack(warrior2)
            );
        }

        [Test]
        public void AtackShouldWork()
        {
            Warrior warrior = new Warrior("Pesho", 10, 50);
            Warrior warrior2 = new Warrior("Ivan", 10, 50);
            warrior.Attack(warrior2);
            Assert.That(warrior2.HP, Is.EqualTo(40));
        }

        [Test]
        public void IfMoreDamageDealDemageShouldBecome0()
        {
            Warrior warrior = new Warrior("Pesho", 60, 50);
            Warrior warrior2 = new Warrior("Ivan", 10, 50);
            warrior.Attack(warrior2);
            Assert.That(warrior2.HP, Is.EqualTo(0));
        }
    }
}