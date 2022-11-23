using NUnit.Framework;
using System;
using System.Linq;

namespace FightingArena.Tests
{
    [TestFixture]
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanInitializeEmptyArena()
        {
            Arena arena = new Arena();
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void CanAddNewWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Pesho", 10, 10);
            arena.Enroll(warrior);
            Assert.That(arena.Warriors.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddNewWarriorShouldAddProperWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Pesho", 10, 10);
            arena.Enroll(warrior);
            Assert.That(arena.Warriors.First(x => x.Name == warrior.Name).Name, Is.EqualTo(warrior.Name));
        }

        [Test]
        public void AddingSameWarriorShouldThrowException()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Pesho", 10, 10);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            arena.Enroll(warrior)
            );
        }

        [Test]
        public void FightWithEmptyAtackerShouldThrowException()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Ivan", 10, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            arena.Fight(null, "Ivan")
            );
        }

        [Test]
        public void FightWithEmptyDefenderShouldThrowException()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Ivan", 10, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            arena.Fight("Ivan", null)
            );
        }

        [Test]
        public void FightWithProperWarriorsShouldWork()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Ivan", 10, 100);
            Warrior warrior2 = new Warrior("Pesho", 10, 100);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            arena.Fight("Ivan", "Pesho");
        }
    }
}