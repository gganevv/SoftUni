using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }

        [Test]
        public void AtackingWithBrokenWeaponShouldThrowException()
        {
            Axe axe = new Axe(10, -1);
            Dummy dummy = new Dummy(10, 10);
            
            Assert.Throws<InvalidOperationException>(() =>
                axe.Attack(dummy)
                );
        }
    }
}