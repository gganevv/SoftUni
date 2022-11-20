using NUnit.Framework;
using System;

namespace _02.TestDummy
{
    [TestFixture]
    public class DummyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(5, 10);
            axe.Attack(dummy);
            Assert.That(dummy.Health, Is.EqualTo(5));
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);
            Axe axe = new Axe(10, 10);
            Assert.Throws<InvalidOperationException>(() =>
                axe.Attack(dummy)
                );

        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(-1, 10);
            Axe axe = new Axe(10, 10);
            int exp = dummy.GiveExperience();
            Assert.That(exp, Is.EqualTo(10));
        }
        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(10, 10);
            Assert.Throws<InvalidOperationException>(() =>
            dummy.GiveExperience()
            );
        }
    }
}